using System;
using System.Threading.Tasks;


namespace AuthAndApi {

    public interface AbleToAuthenticate : DriverContract {

        Task<ValueType> GetOwnerMeta(Authorization authorization);

    }

}
