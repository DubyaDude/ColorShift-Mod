#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColorShift
{
    public static class DubsDebug
    {
        public static string GetPath(Component obj)
        {
            return GetPath(obj.gameObject);
        }

        public static string GetPath(Transform obj)
        {
            return GetPath(obj.gameObject);
        }

        public static string GetPath(GameObject obj)
        {
            string path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            return path;
        }
    }
}
#endif