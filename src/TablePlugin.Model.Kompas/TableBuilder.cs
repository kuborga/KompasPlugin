using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;
using TablePlugin.Model.Parameters;


namespace TablePlugin.Model.Kompas
{
    /// <summary>
    /// Класс для построения 3D модели
    /// </summary>
   public class TableBuilder
    {
        /// <summary>
        /// Коннектор для работы с Компас3D
        /// </summary>
        private KompasConnector _kompasConnector;

        /// <summary>
        /// Параметры стола
        /// </summary>
        private TableParameters _tableParameters;

        /// <summary>
        /// Метод для построение 3D модели
        /// </summary>
        /// <param name="tableParameters">Параметры стола</param>
        public void Build(TableParameters tableParameters)
        {
            _tableParameters = tableParameters;
            _kompasConnector = new KompasConnector();

            CreateTopTable();
            CreateTableLegs();
        }

        /// <summary>
        /// Метод для построения столешницы
        /// </summary>
        private void CreateTopTable() 
        { 
            // Cоздаём эскиз
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Создаём прямоугольник
            var rectangleParam = (ksRectangleParam)_kompasConnector.KsObject.
                GetParamStruct((short)StructType2DEnum.ko_RectangleParam);

            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.ang = 0;
            rectangleParam.height = _tableParameters.TopWidth.Value;
            rectangleParam.width = _tableParameters.TopLength.Value;
            rectangleParam.style = 1;
            doc2D.ksRectangle(rectangleParam);

            sketchDef.EndEdit();
            PressOutSketch(sketchDef, _tableParameters.TopHeight.Value);
        }

        /// <summary>
        /// Метод для построения ножек стола
        /// </summary>
        private void CreateTableLegs()
        {
            // Cоздаём эскиз
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            const double offsetCoordinate = 30.0;
            double legsValue = _tableParameters.LegsDiameters.Value;

            // Координаты центров ножек стола
            var x = new double[4];
            var y = new double[4];

            x[0] = offsetCoordinate + (legsValue / 2);
            y[0] = offsetCoordinate + (legsValue / 2);

            x[1] = _tableParameters.TopLength.Value - (legsValue / 2) - offsetCoordinate;
            y[1] = _tableParameters.TopWidth.Value - (legsValue / 2) - offsetCoordinate;

            x[2] = offsetCoordinate + (legsValue / 2);
            y[2] = _tableParameters.TopWidth.Value - (legsValue / 2) - offsetCoordinate;

            x[3] = _tableParameters.TopLength.Value - (legsValue / 2) - offsetCoordinate;
            y[3] = (legsValue / 2) + offsetCoordinate;

            // Создание окружностей основая ножек
            for (var i = 0; i < x.Length; i++)
            {
                doc2D.ksCircle(x[i], y[i], (_tableParameters.LegsDiameters.Value / 2), 1);
            }

            // Конец редактирования эскиза
            sketchDef.EndEdit();

            // Выдавить
            PressOutSketch(sketchDef, _tableParameters.LegsHeight.Value, side: false);
        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType"></param>
        /// <returns></returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            // Выбор плоскоти
            var plane = (ksEntity)_kompasConnector.Part.
                GetDefaultEntity((short)planeType);

            // Создание эскиза
            var sketch = (ksEntity)_kompasConnector.Part.
                NewEntity((short)Obj3dType.o3d_sketch);

            // Устаналвливаем эскизу рабочую плоскость
            ksSketchDefinition sketchDef = sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();

            return sketchDef;
        }

        /// <summary>
        /// Метод выдавливания по эскизу
        /// </summary>
        /// <param name="sketchDef">Эскиз</param>
        /// <param name="height">Высота выдавливания</param>
        /// <param name="type">Тип выдавливания</param>
        /// <param name="side">Направление выдавливания</param>
        private void PressOutSketch(ksSketchDefinition sketchDef, 
            double height, 
            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossExtrusion, 
            bool side = true) 
        { 
            var extrusionEntity = (ksEntity)_kompasConnector.
                Part.NewEntity((short)type);

            if(type == ksObj3dTypeEnum.o3d_bossExtrusion)
            {
                var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

                // Параметры выдавливания
                extrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;

                // Эскиз операции выдавливания
                extrusionDef.SetSketch(sketchDef);
            }
            else if(type == ksObj3dTypeEnum.o3d_cutExtrusion)
            {
                var extrusionDef = (ksCutExtrusionDefinition)extrusionEntity.GetDefinition();

                // Параметры выдавливания
                extrusionDef.SetSideParam(side, (short)End_Type.etBlind, height);
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;

                extrusionDef.SetSketch(sketchDef);
            }
            extrusionEntity.Create();
        }
    }
}
