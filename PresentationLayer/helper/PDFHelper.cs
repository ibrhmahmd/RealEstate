using BusinessLayer.DTOModels;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;
using System.IO;

namespace PresentationLayer.Helper
{
    public static class PDFHelper
    {
        // Existing method for generating Payment PDF
        public static byte[] GeneratePaymentPDF(PaymentDTO payment)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Add PDF title with styling
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DarkGray);
                pdfDoc.Add(new Paragraph("Invoice", titleFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add company information (optional)
                var companyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
                pdfDoc.Add(new Paragraph("Estate Agency", companyFont));
                pdfDoc.Add(new Paragraph("123 Real Estate St.", companyFont));
                pdfDoc.Add(new Paragraph("City, Country", companyFont));
                pdfDoc.Add(new Paragraph("Phone: +123 456 7890", companyFont));
                pdfDoc.Add(new Paragraph("Email: info@estateagency.com", companyFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add Payment Details Table
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                // Add table headers and data
                AddCellToTable(table, "Payment Method:", true);
                AddCellToTable(table, payment.PaymentMethod);
                AddCellToTable(table, "Reference Number:", true);
                AddCellToTable(table, payment.ReferenceNumber);
                AddCellToTable(table, "Late Fee:", true);
                AddCellToTable(table, payment.LateFee?.ToString("C", new CultureInfo("en-EG")));
                AddCellToTable(table, "Total Amount:", true);
                AddCellToTable(table, payment.Amount.ToString("C", new CultureInfo("en-EG")));
                AddCellToTable(table, "Payment Date:", true);
                AddCellToTable(table, payment.PaymentDate.ToShortDateString());

                pdfDoc.Add(table); // Add table to the PDF

                // Add footer
                pdfDoc.Add(new Paragraph("\nThank you for your business!", companyFont));

                pdfDoc.Close();

                // Return the byte array representing the PDF content
                return stream.ToArray();
            }
        }


        // New method for generating Contract PDF
        public static byte[] GenerateInitialContractPDF(ContractDTO contract)
        {
            if (contract.ContractType == "Lease") { return GenerateInitialLeaseContractPDF(contract); }
            else return GenerateInitialOwnershipContractPDF(contract);
        }



        // Method for generating Lease Contract PDF
        public static byte[] GenerateInitialLeaseContractPDF(ContractDTO leaseContract)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Add PDF title for Lease Contract
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DarkGray);
                pdfDoc.Add(new Paragraph("Lease Contract Agreement", titleFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add note indicating that this contract is initial and not yet in effect
                var noteFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Red); // Optional: make it stand out
                pdfDoc.Add(new Paragraph("**Note:** This contract is initial and not in effect yet. It serves as proof that both parties have read and understood the terms.", noteFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add details of the parties involved
                var textFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
                pdfDoc.Add(new Paragraph($"This lease contract is made between:", textFont));
                pdfDoc.Add(new Paragraph($"Lessor (Party A): Estate Agency", textFont));
                pdfDoc.Add(new Paragraph($"Lessee (Party B): {leaseContract.Occupantname}", textFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add lease-specific contract terms
                pdfDoc.Add(new Paragraph("Lease Terms:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.Black)));
                pdfDoc.Add(new Paragraph($"Condition Check: {(leaseContract.IsConditionCheckRequired ? "Required" : "Not Required")}", textFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add Definitions Section
                pdfDoc.Add(new Paragraph("Definitions:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.Black)));
                foreach (var term in LeaseTermsDefinitions.Keys)
                {
                    pdfDoc.Add(new Paragraph(term, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.Black)));
                    pdfDoc.Add(new Paragraph(GetLeaseTermsDefinitions(term), textFont));
                    pdfDoc.Add(new Paragraph("\n")); // Add space
                }

                // Add placeholders for signatures and date
                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.WidthPercentage = 100;
                signatureTable.SetWidths(new float[] { 1, 1 });

                AddCellToTable(signatureTable, "Lessor Signature: _______________", true);
                AddCellToTable(signatureTable, "Lessee Signature: _______________", true);
                AddCellToTable(signatureTable, "Date: _______________", true);
                AddCellToTable(signatureTable, $"Contract Date: {leaseContract.CreatedOn.ToString("d MMM yyyy")}", true); // Formatted date

                pdfDoc.Add(signatureTable); // Add signature table to the PDF

                // Close the document
                pdfDoc.Close();

                // Return the byte array representing the lease contract PDF
                return stream.ToArray();
            }
        }


        // Method for generating Ownership Contract PDF
        public static byte[] GenerateInitialOwnershipContractPDF(ContractDTO ownershipContract)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Add PDF title for Ownership Contract
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DarkGray);
                pdfDoc.Add(new Paragraph("Ownership Contract Agreement", titleFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add details of the parties involved
                var textFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
                pdfDoc.Add(new Paragraph($"This ownership contract is made between:", textFont));
                pdfDoc.Add(new Paragraph($"Seller (Party A): Estate Agency", textFont));
                pdfDoc.Add(new Paragraph($"Buyer (Party B): {ownershipContract.Occupantname}", textFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add ownership-specific contract terms
                pdfDoc.Add(new Paragraph("Ownership Terms:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.Black)));
                pdfDoc.Add(new Paragraph($"Property: {ownershipContract.PropertyName}", textFont));
                pdfDoc.Add(new Paragraph($"Purchase Price: {ownershipContract.TotalAmount}"));

                // Add Definitions Section
                pdfDoc.Add(new Paragraph("Definitions:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.Black)));
                foreach (var term in OwnershipTermsDefinitions.Keys)
                {
                    pdfDoc.Add(new Paragraph(term, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.Black)));
                    pdfDoc.Add(new Paragraph(GetOwnershipTermsDefinitions(term), textFont));
                    pdfDoc.Add(new Paragraph("\n")); // Add space
                    pdfDoc.Add(new Paragraph("\n")); // Add space
                }
                // Add placeholders for signatures and date
                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.WidthPercentage = 100;
                signatureTable.SetWidths(new float[] { 1, 1 });

                AddCellToTable(signatureTable, "Seller Signature: _______________", true);
                AddCellToTable(signatureTable, "Buyer Signature: _______________", true);
                AddCellToTable(signatureTable, "Date: _______________", true);
                AddCellToTable(signatureTable, $"Contract Date: {ownershipContract.CreatedOn.ToString("d MMM yyyy")}", true); // Formatted date

                pdfDoc.Add(signatureTable); // Add signature table to the PDF

                // Close the document
                pdfDoc.Close();

                // Return the byte array representing the ownership contract PDF
                return stream.ToArray();
            }
        }

        // Helper method to add cells to a table
        private static void AddCellToTable(PdfPTable table, string text, bool isHeader = false)
        {
            var font = isHeader ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.White) : FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
            var cell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = isHeader ? BaseColor.Gray : BaseColor.White,
                Padding = 5,
                Border = Rectangle.BOX
            };
            table.AddCell(cell);
        }
        public static string GetLeaseTermsDefinitions(string term)
        {
            if (LeaseTermsDefinitions.TryGetValue(term, out string definition))
            {
                return definition;
            }
            else
            {
                return "Definition not found.";
            }
        }
        public static string GetOwnershipTermsDefinitions(string term)
        {
            if (OwnershipTermsDefinitions.TryGetValue(term, out string definition))
            {
                return definition;
            }
            else
            {
                return "Definition not found.";
            }
        }

        private static readonly Dictionary<string, string> LeaseTermsDefinitions = new Dictionary<string, string>
        {
            { "Abandonment", "If the Tenant vacates or abandons the Property for a period of up to seven days without informing the Landlord, the Tenant will be considered in default of this Agreement. If the Landlord believes the Tenant has vacated and abandoned the Property, the Landlord is entitled to inspect the Property by providing 24 hours’ notice or the timeframe required under Governing Law, whichever is greater." },
            { "Access", "Upon the start of the Early Move-In or the Term, whichever is applicable, the Landlord agrees to provide entry to the Tenant in the form of keys, fobs, cards, or any type of keyless access to the Property and any shared Common Areas. Access to the Property shall be given after successful payment and receipt of the amounts required at the execution of this Agreement (see attached ‘Amount Due at Signing’)." },
            { "Additional Occupants", "Individuals who have a legal right to reside on the Property with the Tenant. The Tenant agrees to bear all responsibility and liability for the actions made by the Occupants." },
            { "Common Areas", "Defined as all areas and facilities outside the specified Property but within the boundary of the real estate in which it is located and described under Section 15 of this Agreement. Such areas are for the use of the Tenant, Occupants, and Guests in accordance with the rules of the Property." },
            { "Disclosures", "The Disclosures mentioned under Section 23, whether they are attached to this Agreement or distributed to the Tenant separately, are accepted, acknowledged, and understood by the Tenant upon their execution of this Agreement." },
            { "Early Move-In", "If the Tenant is permitted an Early Move-In, and any pro-rated rent is required to be paid, such payment must be made by the Tenant at the execution of this Agreement. If applicable and selected in Section 8, this Early Move-In period shall be protected under the same rights as the Term of this Agreement." },
            { "Furnishings and Appliances", "The Tenant understands that the Furnishings and Appliances mentioned herein are under the Landlord’s ownership and must be returned in the same condition as at the start of the Term, normal wear and tear excepted." },
            { "Governing Law", "This Agreement shall be governed by and construed in accordance with the laws of the jurisdiction where the Property is located." },
            { "Guests", "Refers to individuals who are not a Tenant or an Occupant but are invited onto the Property on behalf of the Tenant. Guests are permitted to stay on the Property for a period of no more than 48 hours." },
            { "Late Fee", "Refers to a penalty accrued by the Tenant in connection to any Rent payment due to the Landlord. The Late Fee shall accumulate in accordance with the terms mentioned herein and Governing Law, abiding by any statutory grace periods that may exist." },
            { "Move-In Inspection", "A Move-In Inspection, if required under this Agreement or Governing Law, shall be to protect the liability of the Tenant and the Security Deposit. Both Parties must acknowledge the Property's condition at the start and the end of the Term." },
            { "Notices", "The official address used for legal communication between the Landlord and Tenant as mentioned in Section 21." },
            { "NSF Fee", "If a Non-Sufficient Funds (NSF) Fee is mentioned herein, and if it is greater than the amount permitted under Governing Law, the amount under Governing Law shall take precedent. If a Non-Sufficient Funds (NSF) Fee is charged to the Tenant, it shall be due and payable immediately." },
            { "Parking", "Any Parking provided by the Landlord shall be at the Tenant’s discretion. The Landlord is not responsible for any damage, property loss, or liability that may occur to the Tenant’s vehicle while parked in the described area." },
            { "Pets", "If any property repairs, odor removal, or other maintenance is required due to the Tenant’s Pets, the costs shall be deducted from the Pet Fee or Security Deposit with an itemized list disclosed to the Tenant." },
            { "Pre-Payment of Rent", "If applicable, the Pre-Payment of Rent is applied to the dates mentioned herein. The Pre-Payment Period cannot be applied to any other timeframe and is non-refundable." },
            { "Party or Parties", "The Landlord and Tenant are each referred to herein as a “Party” and, collectively, as the “Parties.”" },
            { "Property", "The Property is the residential space permitted to be occupied by the Tenant and Occupants as outlined in Section 2." },
            { "Rent", "The first payment of Rent shall be due and payable at the execution of this Agreement. All subsequent Rent payments shall be paid on the due date in accordance with the payment instructions set forth under Section 4." },
            { "Renters Insurance", "It is strongly recommended that the Tenant secures a Renters Insurance policy to cover personal property, which also includes personal liability for their actions." },
            { "Security Deposit", "If required, a Security Deposit is paid by the Tenant to the Landlord at the execution of this Agreement." },
            { "Smoking Policy", "Smoking, under this Agreement, is referred to using a 3rd party device to inhale plant-based or non-plant-based substances." },
            { "Term", "The Term shall be the period of time the Tenant and any Occupants are permitted to reside on the Property as mentioned in Section 3." },
            { "Utilities & Services", "The Tenant is responsible for any Utilities & Services not mentioned in Section 11 as the Landlord’s responsibility." },
            { "Violation of this Agreement", "If the Tenant violates this Agreement, and more than one individual is named as a Tenant, they shall jointly be liable for all obligations under this Agreement." }
        };
        private static readonly Dictionary<string, string> OwnershipTermsDefinitions = new Dictionary<string, string>
        {
            { "Ownership", "The legal right to possess, use, and dispose of property or assets." },
            { "Title", "The legal evidence of a person's ownership of property, often documented in a deed." },
            { "Deed", "A legal document that conveys ownership of real property from one party to another." },
            { "Equity", "The value of an ownership interest in property, calculated as the property's current market value minus any liens or debts against it." },
            { "Freehold", "An estate in real property that is owned outright for an indefinite period." },
            { "Leasehold", "A property tenure where the owner holds rights to use the property for a specified period under a lease agreement." },
            { "Joint Ownership", "A form of property ownership in which two or more parties share ownership rights." },
            { "Tenancy in Common", "A type of joint ownership where each owner has a distinct, transferable share of the property." },
            { "Joint Tenancy", "A type of joint ownership where all owners have equal shares and rights to the property, with the right of survivorship." },
            { "Right of Survivorship", "A legal right that allows joint owners to inherit the share of a deceased owner automatically." },
            { "Liens", "A legal claim against a property, typically used as collateral to secure a loan or debt." },
            { "Encumbrance", "A claim or liability attached to a property that may affect its transferability, such as a lien or easement." },
            { "Easement", "A legal right to use another's property for a specific purpose, such as access to utilities." },
            { "Adverse Possession", "A legal doctrine that allows a person to claim ownership of land under certain conditions, typically involving continuous and open use without the owner's permission." },
            { "Inherit", "To receive ownership of property or assets from a deceased person, typically through a will or by law." },
            { "Trust", "A legal arrangement where a trustee holds and manages property or assets on behalf of beneficiaries." },
            { "Beneficiary", "An individual or entity entitled to receive benefits or assets from a trust or estate." },
            { "Property Transfer", "The legal process of transferring ownership of property from one party to another." },
            { "Purchase Agreement", "A legal contract between a buyer and seller outlining the terms and conditions of a property sale." },
            { "Mortgagor", "The borrower in a mortgage agreement who pledges property as security for a loan." },
            { "Mortgagee", "The lender in a mortgage agreement who provides funds to the mortgagor in exchange for a claim on the property." },
            { "Common Areas", "Parts of a property that are shared among multiple owners or tenants, such as hallways, gardens, and pools." },
            { "Homeowners Association (HOA)", "An organization in a residential community that enforces rules and regulations for property maintenance and use." },
            { "Zoning", "Laws governing how land in a specific area can be used, including residential, commercial, industrial, and agricultural purposes." },
            { "Real Property", "Land and anything permanently affixed to it, such as buildings and improvements." }
        };

    }
}
