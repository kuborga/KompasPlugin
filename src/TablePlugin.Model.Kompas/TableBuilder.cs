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
   public class TableBuilder
    {
        private KompasConnector _kompasConnector;

        private TableParameters _tableParameters;

        public void Build(TableParameters tableParameters)
        {
            _tableParameters = tableParameters;
            _kompasConnector = new KompasConnector();
            _kompasConnector.GetNewPart();

            CreateTopTable();
        }

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
