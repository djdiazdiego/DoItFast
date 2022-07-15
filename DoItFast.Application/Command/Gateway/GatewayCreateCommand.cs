using DoItFast.Application.Dtos.Gateway;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Command.Gateway
{
    public class GatewayCreateCommand : Command<GatewayResponseDto>
    {
        /// <summary>
        /// Serial number
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Human readable name
        /// </summary>
        public string ReadableName { get; set; }
        /// <summary>
        /// Ip address
        /// </summary>
        public string IpAddress { get; set; }

        public List<PeripheralDeviceModel> PeripheralDevices { get; set; }

        public class PeripheralDeviceModel
        {
            /// <summary>
            /// Vendor.
            /// </summary>

            public string Vendor { get; set; }
            /// <summary>
            /// Status.
            /// </summary>
            public PeripheralDeviceStatusValues PeripheralDeviceStatusId { get; set; }
        }
    }
}
