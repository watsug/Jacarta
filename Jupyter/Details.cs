// <copyright file="Details.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>
// <url>https://github.com/watsug/Jacarta</url>

namespace Jacarta.Jupyter
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    public class Details
    {
        public static IDictionary<string, string> Get(object obj)
        {
            var ret = new Dictionary<string, string>();

            var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                ret[prop.Name] = prop.GetValue(obj).ToString();
            }

            return ret;
        }

        public static IList<(string name, string value, string description)> GetWithDescription(object obj)
        {
            var ret = new List<(string name, string value, string description)>();

            var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach(var prop in props)
            {
                var descAttr = (DescriptionAttribute)prop.GetCustomAttribute(typeof(DescriptionAttribute));
                ret.Add((prop.Name, prop.GetValue(obj).ToString(), descAttr.Description));
            }

            return ret;
        }
    }
}
