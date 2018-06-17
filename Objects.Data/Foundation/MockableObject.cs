using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Objects.Data.Attributes;

namespace Objects.Data.Foundation
{
    public abstract class MockableObject<T> where T : new()
    {
        public static T GetMockInstance()
        {
            T obj = new T();
            Type t = obj.GetType();

            foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                foreach (Attribute att in prop.GetCustomAttributes<MockAttribute>())
                    FindAttributeValueAndSetProperty(prop, att, obj);

            foreach (FieldInfo member in t.GetFields(BindingFlags.Public | BindingFlags.Instance))
                foreach (Attribute att in member.GetCustomAttributes<MockAttribute>())
                    FindAttributeValueAndSetMember(member, att, obj);

            return obj;
        }

        private static void FindAttributeValueAndSetProperty(PropertyInfo prop, Attribute att, T instance)
        {
            if (att is MockableInt32Attribute)
            {
                MockableInt32Attribute ca = (MockableInt32Attribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableBoolAttribute)
            {
                MockableBoolAttribute ca = (MockableBoolAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableInt64Attribute)
            {
                MockableInt64Attribute ca = (MockableInt64Attribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableStringAttribute)
            {
                MockableStringAttribute ca = (MockableStringAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableDoubleAttribute)
            {
                MockableDoubleAttribute ca = (MockableDoubleAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableDecimalAttribute)
            {
                MockableDecimalAttribute ca = (MockableDecimalAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableFloatAttribute)
            {
                MockableFloatAttribute ca = (MockableFloatAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null && prop.CanWrite)
                            prop.SetValue(instance, ca.Value, null);
                    }
                    catch { }
                }
            }
            else if (att is MockableUserTypeAttribute)
            {
                MockableUserTypeAttribute ca = (MockableUserTypeAttribute)att;
                if (ca.IsMockable)
                {
                    Type parent = ca.UserType.BaseType;
                    if (prop.PropertyType == ca.UserType && parent.GetGenericTypeDefinition() == typeof(MockableObject<>))
                    {
                        try
                        {
                            object userType = parent.GetMethod("GetMockInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                            prop.SetValue(instance, userType);
                        }
                        catch { }
                    }
                }
            }
            else if (att is MockableCollectionAttribute)
            {
                MockableCollectionAttribute ca = (MockableCollectionAttribute)att;
                if (ca.IsMockable)
                {
                    Type parent = ca.UserType.BaseType;
                    if (prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>) && parent.GetGenericTypeDefinition() == typeof(MockableObject<>))
                    {
                        Type listType = typeof(List<>).MakeGenericType(ca.UserType);
                        IList listInstance = (IList)Activator.CreateInstance(listType);

                        foreach (int i in Enumerable.Range(1, ca.Size))
                        {
                            try
                            {
                                object userType = parent.GetMethod("GetMockInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                                listInstance.Add(userType);
                            }
                            catch { }
                        }
                        prop.SetValue(instance, listInstance);
                    }
                }
            }
        }

        private static void FindAttributeValueAndSetMember(FieldInfo prop, Attribute att, T instance)
        {
            if (att is MockableInt32Attribute)
            {
                MockableInt32Attribute ca = (MockableInt32Attribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableBoolAttribute)
            {
                MockableBoolAttribute ca = (MockableBoolAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);
                    }
                    catch { }
                }
            }
            else if (att is MockableInt64Attribute)
            {
                MockableInt64Attribute ca = (MockableInt64Attribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableStringAttribute)
            {
                MockableStringAttribute ca = (MockableStringAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableDoubleAttribute)
            {
                MockableDoubleAttribute ca = (MockableDoubleAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableDecimalAttribute)
            {
                MockableDecimalAttribute ca = (MockableDecimalAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableFloatAttribute)
            {
                MockableFloatAttribute ca = (MockableFloatAttribute)att;
                if (ca.IsMockable)
                {
                    try
                    {
                        if (prop != null)
                            prop.SetValue(instance, ca.Value);

                    }
                    catch { }
                }
            }
            else if (att is MockableUserTypeAttribute)
            {
                MockableUserTypeAttribute ca = (MockableUserTypeAttribute)att;
                if (ca.IsMockable)
                {
                    Type parent = ca.UserType.BaseType;
                    if (prop.FieldType == ca.UserType && parent.GetGenericTypeDefinition() == typeof(MockableObject<>))
                    {
                        try
                        {
                            object userType = parent.GetMethod("GetMockInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                            prop.SetValue(instance, userType);
                        }
                        catch { }
                    }
                }
            }
            else if (att is MockableCollectionAttribute)
            {
                MockableCollectionAttribute ca = (MockableCollectionAttribute)att;
                if (ca.IsMockable)
                {
                    Type parent = ca.UserType.BaseType;
                    if (prop.FieldType.GetGenericTypeDefinition() == typeof(List<>) && parent.GetGenericTypeDefinition() == typeof(MockableObject<>))
                    {
                        Type listType = typeof(List<>).MakeGenericType(ca.UserType);
                        IList listInstance = (IList)Activator.CreateInstance(listType);

                        foreach (int i in Enumerable.Range(1, ca.Size))
                        {
                            try
                            {
                                object userType = parent.GetMethod("GetMockInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                                listInstance.Add(userType);
                            }
                            catch { }
                        }
                        prop.SetValue(instance, listInstance);
                    }
                }
            }
        }
    }
}
