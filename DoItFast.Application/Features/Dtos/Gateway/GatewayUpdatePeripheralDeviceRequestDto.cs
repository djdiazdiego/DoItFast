﻿using DoItFast.Application.Features.Command.Gateway;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Features.Dtos.Gateway
{
    [FullMap(typeof(GatewayUpdatePeripheralDeviceCommand))]
    public class GatewayUpdatePeripheralDeviceRequestDto : IDto
    {
        /// <summary>
        /// Gateway serial number
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Peripheral Device identifier
        /// </summary>
        public Guid PeripheralDeviceId { get; set; }

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
