using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMVC.Application.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime) =>
         dateTime.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                   ? DateTimeOffset.MinValue
                  : new DateTimeOffset(dateTime);
}

