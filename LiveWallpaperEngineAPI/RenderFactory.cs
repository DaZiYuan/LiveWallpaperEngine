﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Giantapp.LiveWallpaper.Engine
{
    /// <summary>
    /// 定义render类型的实现
    /// </summary>
    /// <typeparam name="Render"></typeparam>
    public static class RenderFactory
    {
        public static List<IRender> Renders { get; set; } = new List<IRender>();

        public static IRender GetRender(WallpaperType dType)
        {
            foreach (var instance in Renders)
            {
                if (instance.SupportedType == dType)
                    return instance;
            }

            return null;
        }

        public static IRender GetRender(string extension)
        {
            foreach (var instance in Renders)
            {
                var exist = instance.SupportedExtension.FirstOrDefault(m => m == extension.ToLower());
                if (exist != null)
                    return instance;
            }

            return null;
        }


        //public static WallpaperType? ResoveType(string filePath)
        //{
        //    var extension = Path.GetExtension(filePath);
        //    foreach (var render in Renders)
        //    {
        //        var exist = render.SupportedExtension.FirstOrDefault(m => m == extension.ToLower());
        //        if (exist != null)
        //            return render.SupportedType;
        //    }
        //    return null;
        //}
    }
}
