using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Data.Attributes
{
    public class MockAttribute : Attribute { }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple=false)]
    public class MockableInt32Attribute : MockAttribute
    {
        public bool IsMockable = true;
        public int Value = 1;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableInt64Attribute : MockAttribute
    {
        public bool IsMockable = true;
        public long Value = 1;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableStringAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public string Value = String.Empty;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableDoubleAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public double Value = 1.0;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableFloatAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public float Value = 1.0F;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableDecimalAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public decimal Value = 1.0m;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableBoolAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public bool Value = false;
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableUserTypeAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public Type UserType;

        public MockableUserTypeAttribute(Type MockType)
        {
            this.UserType = MockType;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false)]
    public class MockableCollectionAttribute : MockAttribute
    {
        public bool IsMockable = true;
        public Type UserType;
        public int Size = 2;

        public MockableCollectionAttribute(Type MockType)
        {
            this.UserType = MockType;
        }
    }
}
