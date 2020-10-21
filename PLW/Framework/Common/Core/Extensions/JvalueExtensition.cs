using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.Core.Extensions
{
    public static class JvalueExtensition
    {
        public static int[] GetPositionValue(this JToken jvalue, string keyGetValue, string keySplit)
        {
            return jvalue.SelectToken(keyGetValue).ToString().Split(keySplit).Select(int.Parse).ToArray();
        }
    }
}
