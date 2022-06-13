using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IJWTAuth
    {
        string Authentication(string username, string password, IKorisnikRepository korisnikRepository);
    }
}
