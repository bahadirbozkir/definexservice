using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using DefinexService.BL.Interfaces;
using DefinexService.DAL.Entity;
using DefinexService.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinexService.BL.Service
{
    public class CreditApplicationService : ICreditApplicationService
    {
        private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork _unitOfWork;

        public CreditApplicationService(IPaymentService paymentService, IUnitOfWork unitOfWork)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IPaymentBankResponse> Proceed(PaymentRequest request)
        {
            var bankConditionsRepository = _unitOfWork.GetRepository<CreditCondition>();
            var bankConditions = await bankConditionsRepository.FindBy(x => x.BankType == request.BankType).ToListAsync();
            var isFitForCredit = false;
            foreach (var condition in bankConditions)
            {
                isFitForCredit = CheckConditions(condition, request);
            }

            if (isFitForCredit)
            {
                var result = _paymentService.ProcessPayment(request);
                return result;
            }

            return new CreditApplicationPaymentResponse { IsSuccess = false };
        }

        private bool CheckConditions(CreditCondition condition, PaymentRequest request)
        {
            switch (condition.ConditionType)
            {
                case DAL.Enum.ConditionType.GreaterOrEqual:
                    decimal.TryParse(condition.ConditionValue, out decimal greaterOrEqualValue);
                    return request.Order.Total >= greaterOrEqualValue;
                case DAL.Enum.ConditionType.CategoryLimitation:
                    var checkCategoryList = string.IsNullOrEmpty(condition.ConditionValue) ? new List<int>() : condition.ConditionValue.Split(',').Select(int.Parse).ToList();
                    return checkCategoryList.Any(x => request.Order.CategoryList.Contains(x));                    
                default:
                    return false;
            }
        }
    }
}
