﻿using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Dtos.Gateway
{
    [FullMap(typeof(PeripheralDevice), ReverseMap = true)]
    public class PeripheralDeviceResponseDto : IDto
    {
        /// <summary>
        /// Peripheral Device identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Vendor.
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public PeripheralDeviceStatusValues PeripheralDeviceStatusId { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTimeOffset Created { get; set; }
    }
}
