using System.Collections.Generic;

namespace Finance.BLL.Interfaces
{
    public interface IRecordMoneyOperation
    {
        void MakeRecords(IMoneyOperationDTO recordDto);
        IMoneyOperationDTO GetRecord(int? id);
        IEnumerable<IMoneyOperationDTO> GetRecords();
    }
}
