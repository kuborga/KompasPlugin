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
        /// Класс для работы с Компас3D
        /// </summary>
        private KompasConnector _kompasConnector;

        /// <summary>
        /// Класс параметров стола
        /// </summary>
        private TableParameters _tableParameters;

        //TODO: Несоответствие XML-комментария сигнатуре метода 
        /// <summary>
        /// Метод для построение 3D модели
        /// </summary>
        /// <param name="tableParameters">Параметры стола</param>
        public void Build(TableParameters tableParameters, LegsType legsType)
        {
            _tableParameters = tableParameters;
            _kompasConnector = new KompasConnector();

            CreateTopTable();
            CreateTableLegs(legsType);
        }

        /// <summary>
        /// Метод для построения столешницы
        /// </summary>
        private void CreateTopTable() 
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            var rectangleParam = 
                (ksRectangleParam)_kompasConnector.KsObject.
                GetParamStruct((short)StructType2DEnum.
                    ko_RectangleParam);

            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.ang = 0;
            rectangleParam.height = _tableParameters.
                GetValue(ParameterType.TableTopWidth);
            rectangleParam.width = _tableParameters.
                GetValue(ParameterType.TableTopLength);
            rectangleParam.style = 1;
            doc2D.ksRectangle(rectangleParam);
            sketchDef.EndEdit();
            PressOutSketch(sketchDef, _tableParameters.
                GetValue(ParameterType.TableTopHeight));
        }

        /// <summary>
        /// Метод для построения ножек стола
        /// </summary>
        private void CreateTableLegs(LegsType legsType)
        {
            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOY);
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            const double offsetCoordinate = 30.0;
            double legsValue = _tableParameters.
                GetValue(ParameterType.TableLegsBase);

            // Координаты центров ножек стола
            var x = new double[4];
            var y = new double[4];

            x[0] = offsetCoordinate + (legsValue / 2);
            y[0] = offsetCoordinate + (legsValue / 2);

            x[1] = _tableParameters.
                       GetValue(ParameterType.TableTopLength)
                   - (legsValue / 2) - offsetCoordinate;
            y[1] = _tableParameters.GetValue(
                    ParameterType.TableTopWidth) - (legsValue / 2)
                                                 - offsetCoordinate;

            x[2] = offsetCoordinate + (legsValue / 2);
            y[2] = _tableParameters.GetValue(
                    ParameterType.TableTopWidth) - (legsValue / 2)
                                                 - offsetCoordinate;

            x[3] = _tableParameters.GetValue(
                    ParameterType.TableTopLength) - (legsValue / 2)
                                                  - offsetCoordinate;
            y[3] = (legsValue / 2) + offsetCoordinate;

            if (legsType == LegsType.RoundLegs)
            {
               // Создание круглого основания ножек
                for (var i = 0; i < x.Length; i++)
                {
                    doc2D.ksCircle(x[i], y[i], (_tableParameters.
                        GetValue(ParameterType.TableLegsBase) / 2.0), 1);
                }
            }
            else if (legsType == LegsType.SquareLegs)
            {
                // Создание квадратного основания ножек
                for (int i = 0; i < x.Length; i++)
                {
                    var rectagleParam = (ksRectangleParam)_kompasConnector.
                        KsObject.GetParamStruct((short)StructType2DEnum.
                            ko_RectangleParam);
                    // добавить чтобы здесь как double делилиись
                    rectagleParam.x = x[i] - 
                                      (_tableParameters.
                                          GetValue(ParameterType.
                                              TableLegsBase) / 2.0);
                    rectagleParam.y = y[i] - 
                                      (_tableParameters.
                                          GetValue(ParameterType.
                                              TableLegsBase) / 2.0);
                    rectagleParam.ang = 0;
                    rectagleParam.height = _tableParameters.
                        GetValue(ParameterType.TableLegsBase);
                    rectagleParam.width = _tableParameters.
                        GetValue(ParameterType.TableLegsBase);
                    rectagleParam.style = 1;
                    doc2D.ksRectangle(rectagleParam);
                }
            }
            else if(legsType == LegsType.TriangularLegs)
            {
                // Создание треугольного основания ножек
                for (int i = 0; i < x.Length; i++)
                {
                    var triangle = (ksRegularPolygonParam)
                        (_kompasConnector.KsObject.GetParamStruct(92));
                    triangle.count = 3;
                    triangle.xc = x[i];
                    triangle.yc = y[i];
                    triangle.ang = 0;
                    triangle.radius = (_tableParameters.
                        GetValue(ParameterType.TableLegsBase) / 2.0) 
                                      * 1.155;
                    triangle.describe = false;
                    triangle.style = 1;
                    doc2D.ksRegularPolygon(triangle, 0);
                }
            }
            sketchDef.EndEdit();
            PressOutSketch(sketchDef, _tableParameters.
                GetValue(ParameterType.TableLegsHeight), side: false);
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

            // Устанавливаем эскизу рабочую плоскость
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
                var extrusionDef = 
                  (ksBossExtrusionDefinition)extrusionEntity.
                      GetDefinition();

                // Параметры выдавливания
                extrusionDef.SetSideParam(side, 
                    (short)End_Type.etBlind, height);
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;

                // Эскиз операции выдавливания
                extrusionDef.SetSketch(sketchDef);
            }
            else if(type == ksObj3dTypeEnum.o3d_cutExtrusion)
            {
                var extrusionDef =
                    (ksCutExtrusionDefinition)extrusionEntity.
                        GetDefinition();

                // Параметры выдавливания
                extrusionDef.SetSideParam(side, (short)End_Type.
                    etBlind, height);
                extrusionDef.directionType = side 
                    ? (short)Direction_Type.dtNormal 
                    : (short)Direction_Type.dtReverse;

                extrusionDef.SetSketch(sketchDef);
            }
            extrusionEntity.Create();
        }

    }
}
