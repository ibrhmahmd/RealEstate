﻿using Microsoft.AspNetCore.Http;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Contract : BaseEntity<Guid>
    {
        [Required]
        public Guid PropertyId { get; set; }

        [Required]
        public Guid OccupantId { get; set; } // Renamed UserID to TenantId
        [StringLength(50)]
        public string Occupantname { get; set; }
        public Guid? AgentId { get; set; } // Optional agent who reviewed the contract

        [Required]
        public Guid? PaymentMethodId { get; set; } // Foreign Key for PaymentMethod



        // Navigation Properties
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

        [ForeignKey("OccupantId")]
        public virtual User? Occupant { get; set; }

        [ForeignKey("AgentId")]
        public virtual User? Agent { get; set; } // Navigation property for the Agent


        [Required, MaxLength(20)]
        public string PropertyName { get; set; }
        [Required, MaxLength(200)]
        public string PropertyLocation { get; set; } // Location of the property
        [Range(0, 20)]
        public int Rooms { get; set; } // Number of rooms in the property

        public virtual ICollection<Payment>? Payments { get; set; } // Payments associated with the contract


        // Additional Contract Information
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AcceptedOn { get; set; }
        public DateTime DeclienedOn { get; set; }
        public int Period { get; set; } // months

        [Required, MaxLength(20)]
        public string ContractType { get; set; } // Lease, Ownership, etc.


        [Range(0, double.MaxValue)]
        public decimal? InitialPayment { get; set; } // Initial down payment or security deposit

        [Range(0, double.MaxValue)]
        public decimal? RecurringPaymentAmount { get; set; } // Monthly rent or installment amount


        [Required, MaxLength(20)]
        public string RecurringPaymentFrequency { get; set; } = "Monthly"; // Monthly, Quarterly, etc.


        [Range(0, double.MaxValue)]
        public decimal? TotalAmount { get; set; } // Total contract amount for sale or lease



        [Required]
        public decimal LateFee { get; set; } // Late payment fee
        public bool IsArcheives { get; set; } = false;
        public bool? IsTerminated { get; set; } = false; // Indicates whether the contract is terminated
        [Required]
        public bool IsConditionCheckRequired { get; set; } = false; // Pre-contract inspections
        public bool IsAccepted { get; set; } = false;
        public bool IsDecliened { get; set; } = false;
        public bool IsFurnished { get; set; } = false; // Is the property furnished?
        public string? Document { get; set; } // Path to the contract document (optional)




    

    }
}