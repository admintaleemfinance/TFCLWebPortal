using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Transactions.Dto;

namespace TFCLPortal.Transactions.Dto
{
    public class TransactionAppService : TFCLPortalAppServiceBase, ITransactionAppService
    {
        private readonly IRepository<Transaction, Int32> _TransactionRepository;
        private string company = "Transaction";
        public TransactionAppService(IRepository<Transaction, Int32> TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }
        public async Task CreateTransaction(CreateTransactionDto input)
        {
            try
            {
                var Transaction = ObjectMapper.Map<Transaction>(input);
                await _TransactionRepository.InsertAsync(Transaction);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", company));
            }
        }
        public  TransactionListDto GetTransactionById(int Id)
        {
            try
            {
                var Transaction = _TransactionRepository.Get(Id);

                return ObjectMapper.Map<TransactionListDto>(Transaction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<TransactionListDto> GetTransactionByAccountId(int AccountId)
        {
            try
            {
                var Transaction = _TransactionRepository.GetAllList(x=>x.Fk_AccountId==AccountId).ToList();

                return ObjectMapper.Map<List<TransactionListDto>>(Transaction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }

        }
        public List<TransactionListDto> GetTransactionListDetail()
        {
            try
            {
                var Transaction = _TransactionRepository.GetAll();

                return ObjectMapper.Map<List<TransactionListDto>>(Transaction);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", company));
            }
        }

        public async Task<string> UpdateTransaction(UpdateTransactionDto input)
        {
            string ResponseString = "";
            try
            {
                var Transaction = _TransactionRepository.Get(input.Id);
                if (Transaction != null && Transaction.Id > 0)
                {
                    ObjectMapper.Map(input, Transaction);
                    await _TransactionRepository.UpdateAsync(Transaction);
                    CurrentUnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", company));
            }
            return ResponseString;
        }
    }
}
