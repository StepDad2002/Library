using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Library.MVC.CustomValidationAttrs;

public class NotEmptyAttribute : RequiredAttribute
{
    public override bool IsValid(object value)
    {
        var list = value as IEnumerable;
        if (list == null)
        {
            // The value is null
            return false;
        }

        foreach (var item in list)
        {
            if (item == null)
            {
                // An item in the collection is null
                return false;
            }
        }

        return true;
    }
}