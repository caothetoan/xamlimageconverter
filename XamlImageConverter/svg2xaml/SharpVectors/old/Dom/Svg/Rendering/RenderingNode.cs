using System;
using System.Windows.Media;
using System.Windows;
    /// <completed>0</completed>
		{
        // define empty handlers by default

        public static bool AssignValue(DependencyObject obj, DependencyProperty prop, object value, object ignoreValue)
        {
            LocalValueEnumerator iter = obj.GetLocalValueEnumerator();
            bool isValueAssigned = false;
            while (iter.MoveNext())
            {
                if (iter.Current.Property == prop)
                {
                    isValueAssigned = true;
                    break;
                }
            }

            if (isValueAssigned || !object.Equals(value, ignoreValue))
            {
                obj.SetValue(prop, value);
                return true;
            }

            if (!object.Equals(value, ignoreValue)
                && !object.Equals(value, prop.DefaultMetadata.DefaultValue))
            {
                obj.SetValue(prop, value);
                return true;
            }
            return false;
        }

        public static bool AssignValue(DependencyObject obj, DependencyProperty prop, object value)
        {
            LocalValueEnumerator iter = obj.GetLocalValueEnumerator();
            bool isValueAssigned = false;
            while (iter.MoveNext())
            {
                if (iter.Current.Property == prop)
                {
                    isValueAssigned = true;
                    break;
                }
            }

            if (isValueAssigned)
            {
                obj.SetValue(prop, value);
                return true;
            }

            if (!object.Equals(value, prop.DefaultMetadata.DefaultValue))
            {
                obj.SetValue(prop, value);
                return true;
            }

            return false;
        }

        public virtual bool CanRenderChildren(ISvgRenderer renderer)
        {
            return true;
        }
    }
}