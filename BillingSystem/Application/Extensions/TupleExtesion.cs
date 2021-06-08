namespace Application.Extensions
{
    public static class TupleExtesion
    {
        public static (int recurringPayment, int remainderPayment) RecurringAndRemainderPaymentCalc(this (int premium, int paymentsCount) self)
            => (self.premium / self.paymentsCount, self.premium % self.paymentsCount);        
    }
}
