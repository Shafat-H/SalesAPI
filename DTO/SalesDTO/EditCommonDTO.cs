using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.DTO.SalesDTO
{
    public class EditCommonDTO
    {
        public EditHeaderDTO Hedit { get; set; }
        public List<EditRowDTO> Redit { get; set; }
    }
}
