using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Domain.Services
{
    public interface IRemoteControlService
    {
        void Start(Guid assetId);
        void Stop(Guid assetId);
    }
}
