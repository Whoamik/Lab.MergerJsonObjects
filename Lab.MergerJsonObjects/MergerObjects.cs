
using System.Reflection; 

namespace Lab.MergerJsonObjects
{
    public static class MergerObjects
    {
        private const BindingFlags FieldFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly string[] BackingFieldFormats = { "<{0}>i__Field", "<{0}>" };
        public static String solutionName = "Lab.MergerJsonObjects";
        public static Dictionary<string, List<string>> getProperties<T>(T objectClass)
        {
            Dictionary<string, List<string>> properties = new Dictionary<string, List<string>>();
            PropertyInfo[] myPropertyInfo = objectClass.GetType().GetProperties();

            List<string> Collections = new List<string>();
            List<string> GetProperties = new List<string>();
            List<string> System = new List<string>();
            foreach (PropertyInfo proInfo in myPropertyInfo)
            {
                try
                {
                    if (proInfo.Name == "id")
                    {
                        continue;
                    }
                    else
                    {
                        if (proInfo.PropertyType == null) continue;
                        if (proInfo.PropertyType.FullName.Contains("Collections"))
                        {
                            Collections.Add(proInfo.Name);
                        }
                        else if (proInfo.PropertyType.FullName.Contains(solutionName) && !proInfo.PropertyType.BaseType.Name.Contains("Enum"))
                        {
                            GetProperties.Add(proInfo.Name);
                        }
                        else if (proInfo.PropertyType.FullName.Contains("AnonymousType") && proInfo.PropertyType.BaseType.Name.Contains("Object"))
                        {
                            GetProperties.Add(proInfo.Name);
                        }
                        else if (proInfo.PropertyType.BaseType.Name.Contains("Enum"))
                        {
                            System.Add(proInfo.Name);
                        }
                        else
                        {
                            System.Add(proInfo.Name);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            properties.Add("Collections", Collections);
            properties.Add(solutionName, GetProperties);
            properties.Add("System", System);

            return properties;
        }
        public static bool Compare<T>(T e1, T e2)
        {
            Dictionary<string, List<string>> dictionary = getProperties(e1);
            bool flag = true;
            bool match = false;
            int countFirst, countSecond;
            foreach (PropertyInfo propObj1 in e1.GetType().GetProperties())
            {
                if (propObj1.Name == "id")
                {
                    continue;
                }
                var propObj2 = e2.GetType().GetProperty(propObj1.Name);
                if (dictionary["Collections"].Any(x => x.Contains(propObj1.Name)))
                {
                    if (propObj1.PropertyType.FullName.Contains(solutionName)
                        && propObj2.PropertyType.FullName.Contains(solutionName))
                    {
                        dynamic objList1 = propObj1.GetValue(e1, null);
                        dynamic objList2 = propObj2.GetValue(e2, null);
                        if (objList1 != null && objList2 != null)
                        {
                            countFirst = objList1.Count;
                            countSecond = objList2.Count;
                            if (countFirst == countSecond)
                            {
                                countFirst = objList1.Count - 1;
                                while (countFirst > -1)
                                {
                                    match = false;
                                    countSecond = objList2.Count - 1;
                                    while (countSecond > -1)
                                    {
                                        match = Compare(objList1[countFirst], objList2[countSecond]);
                                        if (match)
                                        {
                                            //objList2.Remove(objList2[countSecond]);
                                            countSecond = -1;
                                            match = true;
                                        }
                                        if (match == false && countSecond == 0)
                                        {
                                            return true;
                                        }
                                        countSecond--;
                                    }
                                    countFirst--;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        var ClassA = propObj2?.GetValue(e2, null) ?? null;
                        var ClassB = propObj1?.GetValue(e1, null) ?? null;
                        if (ClassA != null)
                        {
                            if (ClassB != null)
                            { 
                                if (!ClassA.Equals(ClassB))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!ClassA.Equals(ClassB))
                            {
                                return false;
                            }
                        }
                    }
                }
                else if (dictionary[solutionName].Any(x => x.Contains(propObj1.Name)))
                {
                    var ClassA = propObj2?.GetValue(e2, null) ?? null;
                    var ClassB = propObj1?.GetValue(e1, null) ?? null;
                    if (ClassA != null)
                    {
                        if (ClassB != null)
                        {
                            flag = match = Compare(ClassA, ClassB);
                            if (!flag)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else if (dictionary["System"].Any(x => x.Contains(propObj1.Name)))
                {
                    if (propObj1.Name == "id")
                    {
                        continue;
                    }
                    var A = propObj1?.GetValue(e1, null) ?? "";
                    var B = propObj2?.GetValue(e2, null) ?? "";
                    if (!A.Equals(B))
                        return false;
                }
            }
            return flag;
        }
        public static bool Merge<T>(T e1, T e2, bool isOverrideZero = false)
        {
            Dictionary<string, List<string>> dictionary = getProperties(e1);
            bool flag = true;
            bool match = false;
            int countFirst, countSecond;
            foreach (PropertyInfo propObj1 in e1.GetType().GetProperties())
            {
                if (propObj1.Name.ToLower() == "id") continue;
                if (e2 == null) continue;
                var propObj2 = e2.GetType().GetProperty(propObj1.Name);
                if (dictionary["Collections"].Any(x => x.Contains(propObj1.Name)))
                {
                    if (propObj1.PropertyType.FullName.Contains(solutionName)
                        && propObj2.PropertyType.FullName.Contains(solutionName))
                    {
                        dynamic objList1 = propObj1.GetValue(e1, null);
                        dynamic objList2 = propObj2.GetValue(e2, null);
                        if (objList1 != null && objList2 != null)
                        {
                            countFirst = objList1.Count;
                            countSecond = objList2.Count;
                            if (countFirst == countSecond)
                            {
                                countFirst = objList1.Count - 1;
                                while (countFirst > -1)
                                {
                                    match = false;
                                    countSecond = objList2.Count - 1;
                                    while (countSecond > -1)
                                    {
                                        match = Merge(objList1[countFirst], objList2[countSecond]);
                                        if (match)
                                        {
                                            objList2.Remove(objList2[countSecond]);
                                            countSecond = -1;
                                            match = true;
                                        }
                                        countSecond--;
                                    }
                                    countFirst--;
                                }
                            }
                            else
                            {
                                if (objList2.Count != 0)
                                {
                                    propObj1.SetValue(e1, objList2 ?? null);
                                }
                            }
                        }
                        else if (objList1 == null)
                        {
                            propObj1.SetValue(e1, propObj2?.GetValue(e2, null) ?? null);
                        }
                    }
                    else
                    {
                        dynamic objList2 = propObj2.GetValue(e2, null);
                        if (objList2 != null && objList2.Count > 0)
                            propObj1.SetValue(e1, propObj2?.GetValue(e2, null) ?? null);
                    }
                }
                //else if (propObj1.PropertyType.Name.Equals("ListAA"))
                else if (dictionary[solutionName].Any(x => x.Contains(propObj1.Name)))
                {
                    var ClassA = propObj1?.GetValue(e1, null) ?? null;
                    var ClassB = propObj2?.GetValue(e2, null) ?? null;
                    if (ClassB != null)
                    {
                        if (ClassA != null)
                        {
                            if (!Compare(ClassA, ClassB))
                            {
                                Merge(ClassA, ClassB);
                            }
                        }
                        else
                        {
                            propObj1.SetValue(e1, propObj2?.GetValue(e2, null) ?? "");
                        }
                    }

                }
                else if (dictionary["System"].Any(x => x.Contains(propObj1.Name)))
                {
                    if (propObj1.Name == "id")
                    {
                        continue;
                    }
                    var A = propObj2?.GetValue(e2, null) ?? "";
                    var B = propObj1?.GetValue(e1, null) ?? "";
                    if (A.ToString() == "" || A == null) continue;
                    if (!isOverrideZero)
                        if (A.ToString() == "0") continue;
                    if (!A.Equals(B))
                    {
                        if (propObj1.CanWrite)
                            propObj1.SetValue(e1, propObj2?.GetValue(e2, null) ?? "");
                        else
                        {
                            Set(e1, propObj1, propObj2?.GetValue(e2, null) ?? "");
                        }
                    }
                }
            }
            return flag;
        }

        public static T Set<T, TProperty>(
            T instance,
            PropertyInfo propExpression,
            TProperty newValue)
        {
            var pi = propExpression;
            var backingFieldNames = BackingFieldFormats.Select(x => string.Format(x, pi.Name)).ToList();
            var fi = instance.GetType()
                .GetFields(FieldFlags)
                .FirstOrDefault(f => backingFieldNames.Contains(f.Name));
            if (fi == null)
                throw new NotSupportedException(string.Format("Cannot find backing field for {0}", pi.Name));
            fi.SetValue(instance, newValue);
            return instance;
        } 
    }
}