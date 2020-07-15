using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bookish.DataAccess.Models
{
    public interface Model
    {
        bool Insert();
        bool Delete();
        
    }
}