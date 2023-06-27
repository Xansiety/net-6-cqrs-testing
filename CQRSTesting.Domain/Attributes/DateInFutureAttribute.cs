using System.ComponentModel.DataAnnotations;

namespace CQRSTesting.Domain.Attributes
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _dateTimeNowProvider;

        // va a venir desde el padre con el valor de DateTime.Now -> seteamos un valor por defecto
        public DateInFutureAttribute() : this(() => DateTime.Now) { }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "Date must be in the future";
        }

        // siempre recibe un object, por eso se hace el cast a DateTime
        public override bool IsValid(object value)
        {
            bool isValid = false;
            // casteo a DateTime -> dateTimeValue es la variable que se regresa
            if (value is DateTime dateTimeValue)
            {
                isValid = dateTimeValue > _dateTimeNowProvider();
            }
            return isValid;
        }
    }
}
