using SalesAPI.DTO.Header;
using SalesAPI.DTO.Row;
using System.Collections.Generic;

namespace SalesAPI.DTO.SalesDTO
{
    public class GetByIdCommonDTO
    {
        public HeaderDTO headerDTO { get; set; }
        public List<RowDTO> rowDTOs { get; set; }
    }
}
