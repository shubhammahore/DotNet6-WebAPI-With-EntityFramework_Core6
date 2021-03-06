CREATE TABLE [dbo].[PoRelease] (
    [Id]                                   INT            IDENTITY (1, 1) NOT NULL,
    [requestingPlant]                      NVARCHAR (100) NULL,
    [poNumber]                             NVARCHAR (100) NULL,
    [highUrgency]                          NVARCHAR (100) NULL,
    [totalPOValue]                         FLOAT (53)     NULL,
    [areaManagerEmail]                     NVARCHAR (100) NULL,
    [requestReason]                        NVARCHAR (100) NULL,
    [customerName]                         NVARCHAR (100) NULL,
    [customerCancellationTerms]            NVARCHAR (100) NULL,
    [CancellationPolicy]                   NCHAR (10)     NULL,
    [isCheckedDnowInventory]               BIT            NULL,
    [isAvailableInCompany]                 BIT            NULL,
    [isUsesItemCodes]                      BIT            NULL,
    [isCollaborateWIthCorporateAndCentral] BIT            NULL,
    [vendorName]                           NVARCHAR (100) NULL,
    [vendorReturnPolicy]                   NVARCHAR (100) NULL,
    [restockingFees]                       NVARCHAR (100) NULL,
    [poType]                               NVARCHAR (100) NULL,
    [isPoGreaterFiftyThousand]             BIT            NULL,
    [additionalNotes]                      NVARCHAR (MAX) NULL,
    [attachment]                           NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

