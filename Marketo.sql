/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdsBanners]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdsBanners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[Image] [nvarchar](1000) NULL,
	[Title] [nvarchar](80) NOT NULL,
	[Text] [nvarchar](255) NOT NULL,
	[IsShared] [bit] NOT NULL,
	[AdsUrl] [nvarchar](1000) NULL,
 CONSTRAINT [PK_AdsBanners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[IsAdmin] [bit] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](255) NULL,
	[EmailConfirmationToken] [nvarchar](max) NULL,
	[PasswordResetToken] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[Image] [nvarchar](1000) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Logo] [nvarchar](1000) NULL,
	[Website] [nvarchar](1000) NULL,
	[IsShared] [bit] NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colours]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Colours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompareLists]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompareLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[AppUserId] [nvarchar](450) NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_CompareLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Displays]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Displays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Displays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[Question] [nvarchar](max) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[IsShared] [bit] NOT NULL,
 CONSTRAINT [PK_FAQs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[Price] [float] NOT NULL,
	[Count] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[Colour] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[AppUserId] [nvarchar](450) NULL,
	[TotalPrice] [float] NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Country] [nvarchar](255) NOT NULL,
	[City] [nvarchar](255) NOT NULL,
	[ZipCode] [nvarchar](255) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PowerSources]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PowerSources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_PowerSources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColours]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ColourId] [int] NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_ProductColours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductFeatures]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[FeatureId] [int] NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Image] [nvarchar](1000) NULL,
	[ProductId] [int] NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[MainImage] [nvarchar](1000) NULL,
	[Price] [money] NOT NULL,
	[DiscountPrice] [money] NULL,
	[ExTax] [money] NOT NULL,
	[Count] [int] NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[BrandId] [int] NULL,
	[DisplayId] [int] NULL,
	[PowerSourceId] [int] NULL,
	[SpecialTypeId] [int] NULL,
	[IsNewArrival] [bit] NOT NULL,
	[ShareOnHomeSlide] [bit] NOT NULL,
	[SlideImage] [nvarchar](1000) NULL,
	[PosterImage] [nvarchar](1000) NULL,
	[ShareAsPoster] [bit] NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
	[Gender] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTags]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[TagId] [int] NULL,
 CONSTRAINT [PK_ProductTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Comment] [nvarchar](1000) NOT NULL,
	[Star] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
	[AppUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicePolicies]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicePolicies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Image] [nvarchar](1000) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ServicePolicies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Logo] [nvarchar](1000) NULL,
	[Offer] [nvarchar](255) NULL,
	[Phone2] [nvarchar](255) NULL,
	[Email1] [nvarchar](255) NOT NULL,
	[Email2] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Facebook] [nvarchar](1000) NULL,
	[Instagram] [nvarchar](1000) NULL,
	[Twitter] [nvarchar](1000) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[SupportPhone] [nvarchar](255) NOT NULL,
	[SupportText] [nvarchar](255) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[AppUserId] [nvarchar](450) NULL,
	[ProductId] [int] NULL,
	[Count] [int] NOT NULL,
	[ColourId] [int] NULL,
 CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecialTypes]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Image] [nvarchar](1000) NULL,
	[IsShared] [bit] NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_SpecialTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[RestoredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 27.12.2022 20:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[RestoredAt] [datetime2](7) NULL,
	[AppUserId] [nvarchar](450) NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_Wishlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619210712_CreatedSettingsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619212033_CreatedBrandsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619212750_CreatedDisplaysTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619213430_CreatedPowerSourcesTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619214251_CreatedSpecialTypesTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619214908_CreatedTagsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619225034_CreatedColoursTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619225619_CreatedFeaturesTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619233302_CreatedProductsTableWithRelations', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619235620_CreatedProductImagesTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220620212133_CreatedReviewsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220621172856_AddedIsNewArrivalColumnToProductsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220621173751_AddedSlidePropertiesColumnsToProductsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220621174635_AddedServicePoliciesTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220621215549_AddedPosterColumnsToProductsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220621220610_AddedRestoredAtColumnBaseEntity', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220623142754_UpdatedProductTabelAddedGendeColumn', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624080854_EditedProductTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624095301_EditedProductTable_v2', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624113350_EditedProductTableRelations', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624140412_EditedDiscountPriceNullable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220624163450_DeletedSKUColumn', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220627135147_AddedFAQsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220627140452_AddedIsSharedToFAQsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629071507_EditedSettingsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629083237_CreatedBlogsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629083708_EditedBlogsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629163834_AddedAdsBannerTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629165311_EditedAdsBannerTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220630063739_AddedAdsUrlToAdsBannersTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220630093221_EditedProductDescriptionColumn', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220702164907_AddedAppUserOrdersOrderItemsShoppingCartsTables', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703105634_AddedCompareListsWishlistsTables', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220705070135_EditedShoppingCartsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220706121100_EditedOrdersTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220706124116_UpdatedAppUsersTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220706221824_AddedColourToOrderItemsTable', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220706223416_AddedColourToOrderItemsTable_v2', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220706224924_CreatedContactsTableForMessages', N'3.1.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220708074301_EditedReviewsTable', N'3.1.25')
GO
SET IDENTITY_INSERT [dbo].[AdsBanners] ON 

INSERT [dbo].[AdsBanners] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Image], [Title], [Text], [IsShared], [AdsUrl]) VALUES (1, 0, CAST(N'2022-06-30T10:15:13.4956245' AS DateTime2), CAST(N'2022-07-07T11:30:18.8052183' AS DateTime2), CAST(N'2022-07-07T11:29:48.3156213' AS DateTime2), CAST(N'2022-07-07T11:29:54.2951816' AS DateTime2), N'4be44ee4-c43b-4391-8bf6-325f88ffc5a9_202206301015134935_banner.jpg', N'CASIO G-Shock Rubiks Cube Limited Edition', N'We�re excited to announce the GAE-2100RC, a collaboration based on one of the best-selling toys in history, the iconic Rubik�s Cube.', 1, N'https://www.klockia.se/en/casio-g-shock-rubiks-cube-limited-edition')
SET IDENTITY_INSERT [dbo].[AdsBanners] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2e2653f4-3acb-42b3-b558-2a41d82683b6', N'SuperAdmin', N'SUPERADMIN', N'942377ad-2a91-4084-81a6-114f42602b31')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9f1291fa-c0ce-4abc-9729-3a5c233ccb60', N'Customer', N'CUSTOMER', N'e14063f2-1512-4a75-aa48-cd8be170f48c')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a8a6c3a2-c50c-4df0-9da4-d1794360b2b3', N'Admin', N'ADMIN', N'e3267dbc-8695-4e16-baee-c00a2ad22679')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3e889ed4-6d3f-4df1-9edf-22a04418a114', N'2e2653f4-3acb-42b3-b558-2a41d82683b6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'706e1bd4-551f-4bd3-aa63-394d7886e3ac', N'9f1291fa-c0ce-4abc-9729-3a5c233ccb60')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eba78b68-474f-4362-bb71-ab802f952700', N'9f1291fa-c0ce-4abc-9729-3a5c233ccb60')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsAdmin], [Address], [Country], [City], [ZipCode], [EmailConfirmationToken], [PasswordResetToken]) VALUES (N'3e889ed4-6d3f-4df1-9edf-22a04418a114', N'quliyev039', N'QULIYEV039', N'kamilag@code.edu.az', N'KAMILAG@CODE.EDU.AZ', 1, N'AQAAAAEAACcQAAAAEBw7fYV84sZjZImWrEraLkeBjIcIYHNTpRzR5nhczEQl2KnPsVrcLs0PVq9IY9PlYQ==', N'TAGJ665U3KSRRYOWWHRKOLM3M3BLDYLP', N'b8efcd4e-0569-4572-85da-c3438f682eca', NULL, 0, 0, NULL, 1, 0, N'Kamil Guliyev', 1, NULL, NULL, NULL, NULL, N'f6b781fc-f101-40a5-abc8-9318c2db69e4', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsAdmin], [Address], [Country], [City], [ZipCode], [EmailConfirmationToken], [PasswordResetToken]) VALUES (N'706e1bd4-551f-4bd3-aa63-394d7886e3ac', N'tester1', N'TESTER1', N'web.developer.kamil@gmail.com', N'WEB.DEVELOPER.KAMIL@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHcFMVoX5Kfj0kaJOnYdiu4Y56RcZ2eHxuRHLd9x+pox8rKolhB14DoEFwnCbDvdvw==', N'DY5VKAVQK7J5B3CWOQOS36BE74VBRUWF', N'732a910d-32f8-4374-9b66-ba646d74c394', NULL, 0, 0, NULL, 1, 0, N'Mr. Tester', 0, NULL, NULL, NULL, NULL, N'24e6a627-c861-444b-9911-8db646e55a7e', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsAdmin], [Address], [Country], [City], [ZipCode], [EmailConfirmationToken], [PasswordResetToken]) VALUES (N'eba78b68-474f-4362-bb71-ab802f952700', N'kamil750', N'KAMIL750', N'kamil-k750@mail.ru', N'KAMIL-K750@MAIL.RU', 1, N'AQAAAAEAACcQAAAAENzq4PH87+SxNVEUYH8HHDEusdHxrGlWAqzIYQJow5k7qr8cnodbSTODgKaghw3mpw==', N'IFMQEK7T4D2ZZCQ3GEBC3AMEDLWPUZH4', N'18498dc2-68ec-4f13-a8a1-0fd48ea0b148', NULL, 0, 0, NULL, 1, 0, N'Kamil Quliyev', 0, NULL, NULL, NULL, NULL, N'4d84eb7f-d1ba-4359-95a2-502ffc4f4da2', NULL)
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Image], [Title], [Content], [CreatedBy]) VALUES (2, 0, CAST(N'2022-06-29T20:20:29.3151788' AS DateTime2), NULL, NULL, NULL, N'88ffb1a3-92e7-42d1-af70-2d50f305ee4d_202206292020293127_1.jpg', N'Why should you know types of watches?', N'<p>You need to know clearly about types of watches because you can not wear your kid&rsquo;s watch in the meeting or your wife is not suitable with your giant sports watch. There are many different types of watches in the other worlds that are suitable for different personal styles and occasions. Once you are aware of all watch types, you can narrow down your choices when you start to buy a watch or choose a watch to wear before going out.</p>

<p>If you think all watches are the same, your decision will be much more complicated. I&rsquo;m sure that you will know better about the watch&rsquo;s features and some specifications from my page. Indeed, you and your people will appreciate your watch gift.</p>

<p>With the wide range of types of watches available, your decision might be challenging from the beginning. However, be my companion for finding out all types of watches carefully from watch&rsquo;s types, features, band, shapes, and the purposes of use, everything will become simple as a piece of cake. Besides, even if you are not a beginner and are owning several watches, this knowledge might be beneficial for those passionate about watch collection.</p>
', NULL)
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Tissot', N'tissot.png', N'https://www.tissotwatches.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (2, 0, NULL, CAST(N'2022-06-27T05:35:49.6362709' AS DateTime2), NULL, N'Rolex', N'rolex.png', N'https://www.rolex.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Cartier', N'cartier.png', N'https://www.cartier.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Patek Philippe', N'522e0347-6483-4d83-9c08-5238eb04f3c4_202206221542033821_patek-philippe.png', N'https://www.patek.com/', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (5, 0, NULL, NULL, CAST(N'2022-06-30T11:36:44.4511813' AS DateTime2), N'Audemars Piguet', N'36884a6d-84d4-4fb9-904e-d2f621cf331d_202206221539301074_audemars-piguet.png', N'https://www.audemarspiguet.com/', 0, CAST(N'2022-06-30T11:36:47.7201669' AS DateTime2))
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (6, 0, NULL, NULL, NULL, N'Hublot', N'hublot.png', N'https://www.hublot.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (7, 0, NULL, CAST(N'2022-06-30T13:28:41.2798578' AS DateTime2), NULL, N'Citizen', N'citizen.png', N'https://www.citizenwatch.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (8, 0, NULL, NULL, NULL, N'Seiko', N'seiko.png', N'https://www.seikowatches.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (9, 0, NULL, NULL, NULL, N'Casio', N'casio.png', N'https://www.casio.com/', 1, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (10, 0, NULL, NULL, NULL, N'Olivia Burton', N'fe648bd6-98a3-4b48-8ca0-337ac66158cc_202206221536451196_olivia-burton.png', N'https://www.oliviaburton.com/', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (11, 0, NULL, NULL, NULL, N'Michael Kors', N'5486aa79-e7ca-499e-90c6-1b322b98546f_202206221536550901_michael-kors.png', N'https://www.michaelkors.com', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (12, 0, NULL, NULL, NULL, N'Diesel', N'4b1959bb-e347-4ebc-84c1-fb53cb407760_202206221507331820_diesel.png', N'https://global.diesel.com/', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (13, 0, NULL, NULL, NULL, N'Certina', NULL, NULL, 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (14, 0, NULL, NULL, NULL, N'Longines', NULL, NULL, 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (15, 0, CAST(N'2022-06-27T23:54:10.9883350' AS DateTime2), NULL, NULL, N'Garmin', NULL, N'https://www.garmin.com/en-US/', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (16, 0, CAST(N'2022-06-28T00:11:29.1945544' AS DateTime2), NULL, NULL, N'Police', NULL, NULL, 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (17, 0, CAST(N'2022-06-28T01:54:31.9215846' AS DateTime2), NULL, NULL, N'Aviator', NULL, NULL, 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (18, 0, CAST(N'2022-06-28T02:11:25.8868873' AS DateTime2), NULL, NULL, N'MWC', NULL, N'https://mwcwatches.com/', 0, NULL)
INSERT [dbo].[Brands] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Logo], [Website], [IsShared], [RestoredAt]) VALUES (19, 0, CAST(N'2022-06-28T02:34:24.9402093' AS DateTime2), NULL, NULL, N'Jean Pierre', NULL, N'https://jeanpierre-of-switzerland.com/', 0, NULL)
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Colours] ON 

INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Blue', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'Red', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Green', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Black', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (5, 0, NULL, NULL, NULL, N'White', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (6, 0, NULL, NULL, NULL, N'Grey', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (7, 0, NULL, NULL, NULL, N'Brown', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (8, 0, NULL, NULL, NULL, N'Pink', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (9, 0, NULL, NULL, NULL, N'Yellow', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (10, 0, NULL, NULL, NULL, N'Purple', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (11, 0, NULL, NULL, NULL, N'Orange', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (12, 0, NULL, NULL, NULL, N'Gold', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (13, 0, NULL, NULL, CAST(N'2022-06-30T11:20:35.0725633' AS DateTime2), N'Aqua', CAST(N'2022-06-30T11:20:37.6963411' AS DateTime2))
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (14, 0, NULL, NULL, NULL, N'Silver', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (15, 0, NULL, NULL, NULL, N'Lime', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (16, 0, NULL, NULL, NULL, N'Maroon', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (17, 0, NULL, NULL, NULL, N'Olive', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (18, 0, NULL, NULL, NULL, N'Navy', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (19, 0, NULL, NULL, NULL, N'Crimson', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (20, 0, NULL, NULL, NULL, N'Cyan', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (21, 0, NULL, NULL, NULL, N'Chocolate', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (22, 0, NULL, NULL, NULL, N'Skyblue', NULL)
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (23, 0, CAST(N'2022-06-27T01:25:20.2467022' AS DateTime2), NULL, CAST(N'2022-06-30T11:33:44.9389901' AS DateTime2), N'Teal', CAST(N'2022-06-30T11:33:48.0540452' AS DateTime2))
INSERT [dbo].[Colours] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (24, 0, CAST(N'2022-06-27T01:26:04.4591872' AS DateTime2), NULL, NULL, N'Indigo', NULL)
SET IDENTITY_INSERT [dbo].[Colours] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [FirstName], [LastName], [Email], [Message]) VALUES (1, 0, CAST(N'2022-07-07T04:11:56.9484640' AS DateTime2), CAST(N'2022-07-07T04:21:22.9528088' AS DateTime2), CAST(N'2022-07-07T04:21:13.3565015' AS DateTime2), NULL, N'Kamil', N'Quliyev', N'kamil-k750@mail.ru', N'You are the best! :)')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [FirstName], [LastName], [Email], [Message]) VALUES (2, 0, CAST(N'2022-07-07T04:26:38.4699984' AS DateTime2), NULL, NULL, NULL, N'Mr', N'Tester', N'web.developer.kamil@gmail.com', N'Hmm')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Displays] ON 

INSERT [dbo].[Displays] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Analog', NULL)
INSERT [dbo].[Displays] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'Digital', NULL)
INSERT [dbo].[Displays] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Hybrid', NULL)
INSERT [dbo].[Displays] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Tactile', NULL)
INSERT [dbo].[Displays] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (5, 0, NULL, NULL, NULL, N'Touchscreen', NULL)
SET IDENTITY_INSERT [dbo].[Displays] OFF
GO
SET IDENTITY_INSERT [dbo].[FAQs] ON 

INSERT [dbo].[FAQs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Question], [Answer], [IsShared]) VALUES (1, 0, NULL, CAST(N'2022-06-28T01:25:56.5673626' AS DateTime2), CAST(N'2022-06-27T19:51:23.9729272' AS DateTime2), CAST(N'2022-06-27T19:51:32.7797643' AS DateTime2), N'What is a Chronometer?', N'Chronometer is a Greek word meaning �timekeeper�. Today, only precision watches with a high level of accuracy may call themselves a chronometer, a designation that is subject to strict international test conditions. The independent Swiss monitoring organisation Contr�le Officiel Suisse des Chronom�tres (COSC) tests watches for 15 days in five different positions and at three temperature levels.', 1)
INSERT [dbo].[FAQs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Question], [Answer], [IsShared]) VALUES (2, 0, CAST(N'2022-06-27T19:45:25.1679246' AS DateTime2), CAST(N'2022-06-28T01:27:11.3087586' AS DateTime2), CAST(N'2022-06-27T19:51:19.6032976' AS DateTime2), CAST(N'2022-06-27T19:51:29.4064226' AS DateTime2), N'What is a Chronograph?', N'Chronograph literally means �time writer�. You can both tell the time with a chronograph and use it to measure intervals of time.', 1)
INSERT [dbo].[FAQs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Question], [Answer], [IsShared]) VALUES (3, 0, CAST(N'2022-06-28T01:30:07.2341993' AS DateTime2), NULL, NULL, NULL, N'What is the normal deviation in rate of a mechanical watch per day?', N'The daily deviation in rate of a mechanical watch depends on several important factors. This includes the quality of the movement, the wearing habits of the owner and the influence of extreme temperature differences. However, a quality watch that is in good shape may run up to 10 seconds fast per day.', 1)
INSERT [dbo].[FAQs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Question], [Answer], [IsShared]) VALUES (4, 0, CAST(N'2022-06-28T01:38:29.4932184' AS DateTime2), NULL, NULL, NULL, N'Who created the first wrist watch?', N'The first wristwatch was made for Countess Koscowicz of Hungary by the Swiss watch manufacturer Patek Philippe in 1868, according to Guinness World Records.', 1)
INSERT [dbo].[FAQs] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [Question], [Answer], [IsShared]) VALUES (5, 0, CAST(N'2022-06-28T01:47:09.0211253' AS DateTime2), CAST(N'2022-06-28T01:47:59.4897438' AS DateTime2), NULL, NULL, N'What is special about a pilots watch?', N'Large and highly legible open dial with prominent, high-contrast hands, Arabic numerals, and indexes. Flight computer bezel markings to assist with fuel burn, wind correction angle, and other calculations. Dual time or GMT functions to track local time, destination time, and UTC.', 1)
SET IDENTITY_INSERT [dbo].[FAQs] OFF
GO
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Alarm', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'Light', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Waterproof', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Date', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (5, 0, NULL, NULL, NULL, N'Day of the week', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (6, 0, NULL, NULL, NULL, N'Chronograph', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (7, 0, NULL, NULL, NULL, N'Bluetooth', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (8, 0, NULL, NULL, NULL, N'WiFi', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (9, 0, CAST(N'2022-06-28T01:04:48.7091984' AS DateTime2), NULL, NULL, N'GPS', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (10, 0, CAST(N'2022-06-28T01:05:59.0755461' AS DateTime2), NULL, NULL, N'Compass', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (11, 0, CAST(N'2022-06-28T01:07:25.9695703' AS DateTime2), NULL, NULL, N'Accelerometer', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (12, 0, CAST(N'2022-06-28T01:07:40.1850878' AS DateTime2), NULL, NULL, N'Thermometer', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (13, 0, CAST(N'2022-06-28T01:08:25.6240338' AS DateTime2), NULL, NULL, N'Weather', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (14, 0, CAST(N'2022-06-28T01:08:56.6395467' AS DateTime2), NULL, NULL, N'Find My Phone', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (15, 0, CAST(N'2022-06-28T01:09:04.0442526' AS DateTime2), NULL, NULL, N'Find My Watch', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (16, 0, CAST(N'2022-06-28T01:09:46.6948526' AS DateTime2), NULL, NULL, N'Step Counter', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (17, 0, CAST(N'2022-06-28T01:10:04.7893355' AS DateTime2), NULL, NULL, N'Calories Burned', NULL)
INSERT [dbo].[Features] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (18, 0, CAST(N'2022-06-28T02:05:27.9499001' AS DateTime2), NULL, NULL, N'Phosphorus', NULL)
SET IDENTITY_INSERT [dbo].[Features] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (1, 0, CAST(N'2022-07-07T11:13:14.9257740' AS DateTime2), NULL, NULL, NULL, 1, 4, 1399, 1, 1399, N'Black')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (2, 0, CAST(N'2022-07-07T11:13:14.9257935' AS DateTime2), NULL, NULL, NULL, 1, 8, 290, 1, 290, N'Black')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (3, 0, CAST(N'2022-07-07T11:13:14.9257941' AS DateTime2), NULL, NULL, NULL, 1, 9, 1155, 1, 1155, N'Blue')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (4, 0, CAST(N'2022-07-07T11:18:32.0897510' AS DateTime2), NULL, NULL, NULL, 2, 17, 650, 1, 650, N'Green')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (5, 0, CAST(N'2022-07-07T11:18:32.0897638' AS DateTime2), NULL, NULL, NULL, 2, 16, 1399, 1, 1399, N'Skyblue')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (6, 0, CAST(N'2022-07-07T11:18:32.0897645' AS DateTime2), NULL, NULL, NULL, 2, 13, 1800, 1, 1800, N'Black')
INSERT [dbo].[OrderItems] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [OrderId], [ProductId], [Price], [Count], [TotalPrice], [Colour]) VALUES (7, 0, CAST(N'2022-07-07T11:18:32.0897647' AS DateTime2), NULL, NULL, NULL, 2, 13, 1800, 1, 1800, N'Grey')
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [AppUserId], [TotalPrice], [Address], [Country], [City], [ZipCode], [Status]) VALUES (1, 0, CAST(N'2022-07-07T11:13:14.9258773' AS DateTime2), CAST(N'2022-07-07T12:17:40.8954571' AS DateTime2), NULL, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac', 5688, N'Baku, Azerbaijan', N'Azerbaijan', N'Baku', N'AZ1000', 2)
INSERT [dbo].[Orders] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [RestoredAt], [AppUserId], [TotalPrice], [Address], [Country], [City], [ZipCode], [Status]) VALUES (2, 0, CAST(N'2022-07-07T11:18:32.0898313' AS DateTime2), CAST(N'2022-07-07T12:17:47.3210924' AS DateTime2), NULL, NULL, N'eba78b68-474f-4362-bb71-ab802f952700', 11298, N'Baku, Azerbaijan', N'Azerbaijan', N'Baku', N'AZ1000', 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[PowerSources] ON 

INSERT [dbo].[PowerSources] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Solar', NULL)
INSERT [dbo].[PowerSources] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'Quartz', NULL)
INSERT [dbo].[PowerSources] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Smartwatch', NULL)
SET IDENTITY_INSERT [dbo].[PowerSources] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductColours] ON 

INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (4, 4, 4, 12)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (5, 4, 14, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (6, 4, 6, 16)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (7, 5, 12, 18)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (8, 6, 6, 30)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (15, 7, 12, 30)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (16, 3, 1, 20)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (17, 3, 2, 12)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (18, 3, 5, 8)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (19, 3, 13, 10)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (20, 8, 4, 22)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (21, 8, 6, 12)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (45, 10, 14, 5)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (46, 10, 5, 10)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (54, 11, 1, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (55, 11, 4, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (56, 11, 6, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (57, 11, 14, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (60, 12, 4, 5)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (61, 12, 14, 5)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (62, 13, 4, 20)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (63, 13, 6, 15)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (64, 14, 1, 16)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (69, 15, 3, 6)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (70, 15, 21, 7)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (71, 15, 7, 8)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (72, 16, 22, 10)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (73, 16, 5, 12)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (78, 9, 1, 14)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (79, 9, 2, 12)
INSERT [dbo].[ProductColours] ([Id], [ProductId], [ColourId], [Count]) VALUES (86, 17, 3, 16)
SET IDENTITY_INSERT [dbo].[ProductColours] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductFeatures] ON 

INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (4, 4, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (5, 5, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (6, 6, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (9, 3, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (10, 3, 3)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (29, 11, 1)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (30, 11, 2)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (32, 12, 2)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (33, 13, 8)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (34, 13, 13)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (35, 13, 12)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (36, 13, 16)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (37, 13, 2)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (38, 13, 15)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (39, 13, 14)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (40, 13, 9)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (41, 13, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (42, 13, 10)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (43, 13, 17)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (44, 13, 7)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (45, 13, 1)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (46, 13, 11)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (47, 13, 5)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (48, 14, 4)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (49, 14, 5)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (55, 9, 6)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (56, 9, 3)
INSERT [dbo].[ProductFeatures] ([Id], [ProductId], [FeatureId]) VALUES (59, 17, 3)
SET IDENTITY_INSERT [dbo].[ProductFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'0abd5941-6d26-4cc9-a717-3314a222f689_202206251124001984_certina-2.jpg', 3, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'c7e33d2b-ab51-487d-ab50-debaee3edade_202206251124001995_certina-3.jpg', 3, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'ae528823-f5eb-4d36-9ec5-7638c7887017_202206251124002003_certina-4.jpg', 3, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (5, 0, CAST(N'2022-06-25T13:31:17.8819797' AS DateTime2), NULL, NULL, N'4bf6475d-c5f7-41dd-944b-7106f927aa42_202206251331178809_seiko-2.jpg', 4, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (6, 0, CAST(N'2022-06-25T13:31:17.8836069' AS DateTime2), NULL, NULL, N'314a6ba4-3b0e-41ca-b26f-5a0abcd08e9b_202206251331178821_seiko-3.jpg', 4, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (7, 0, CAST(N'2022-06-25T13:52:12.0324232' AS DateTime2), NULL, NULL, N'42c9b1e2-75b0-4aa3-8d04-2a99af811001_202206251352120312_tissot-t1374103302100-sida.jpg', 5, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (8, 0, CAST(N'2022-06-25T13:52:12.0332593' AS DateTime2), NULL, NULL, N'afc5f3ef-3185-46c5-abe4-e5d4c0c90733_202206251352120324_tissot-t1374103302100-baksida.jpg', 5, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (9, 0, CAST(N'2022-06-25T14:02:33.3700102' AS DateTime2), NULL, NULL, N'0d0432d3-5d6a-4648-9937-7be0e13f2777_202206251402333687_ae528823-f5eb-4d36-9ec5-7638c7887017_202206251124002003_certina-4.jpg', 6, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (10, 0, CAST(N'2022-06-27T00:57:35.0808456' AS DateTime2), NULL, NULL, N'f6cd953a-93b5-4c83-a151-81ea100aec77_202206270057350799_mk-2.jpg', 7, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (11, 0, CAST(N'2022-06-27T00:57:35.0816115' AS DateTime2), NULL, NULL, N'e6b60007-a921-4f63-9483-0cd414fb2d9a_202206270057350808_mk-3.jpg', 7, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (12, 0, CAST(N'2022-06-27T00:57:35.0823469' AS DateTime2), NULL, NULL, N'e4f73fcb-d45c-4322-a62a-aaa04f4d42ee_202206270057350816_mk-4.jpg', 7, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (13, 0, CAST(N'2022-06-27T01:39:23.4595733' AS DateTime2), NULL, NULL, N'e32f96a8-6c19-4828-a676-203e6137ef0b_202206270139234583_mk-2.jpg', 8, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (14, 0, CAST(N'2022-06-27T02:14:42.6706431' AS DateTime2), NULL, NULL, N'abba3ba1-9b4b-421e-b8e6-9216ff139be7_202206270214426696_tissot-2.jpg', 9, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (15, 0, CAST(N'2022-06-27T02:14:42.6714171' AS DateTime2), NULL, NULL, N'eb1729e2-7fd8-48f4-b7d6-8579cf1f939e_202206270214426707_tissot-3.jpg', 9, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (16, 0, CAST(N'2022-06-27T02:14:42.6721818' AS DateTime2), NULL, NULL, N'b422fc23-d0d0-4ce1-bd8d-8de51dd21c8c_202206270214426714_tissot-4.jpg', 9, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (17, 0, CAST(N'2022-06-27T02:14:42.6728193' AS DateTime2), NULL, NULL, N'907c305c-a201-47b8-adcc-1821723ce72f_202206270214426721_tissot-5.jpg', 9, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (18, 0, CAST(N'2022-06-27T23:28:51.3296937' AS DateTime2), NULL, NULL, N'f9a2f2ed-3162-4cda-a21f-c9e3f453d1f7_202206272328513286_tissot-pocket-2.jpg', 10, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (19, 0, CAST(N'2022-06-27T23:28:51.3303503' AS DateTime2), NULL, NULL, N'ae73aefe-0274-4c2a-8364-c19517d72dbd_202206272328513297_tissot-pocket-3.jpg', 10, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (20, 0, CAST(N'2022-06-27T23:28:51.3307625' AS DateTime2), NULL, NULL, N'd421a6f6-14c9-4a5c-be04-f24a990adcba_202206272328513303_tissot-pocket-4.jpg', 10, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (21, 0, CAST(N'2022-06-28T00:19:48.4397690' AS DateTime2), NULL, NULL, N'd9722378-c9c3-417e-8f6a-4262d89b5d9d_202206280019484386_police-2.jpg', 11, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (22, 0, CAST(N'2022-06-28T00:19:48.4402370' AS DateTime2), NULL, NULL, N'1a26238c-7f65-4e0f-b99d-941e086d9161_202206280019484397_police-3.jpg', 11, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (23, 0, CAST(N'2022-06-28T00:32:40.6786099' AS DateTime2), NULL, NULL, N'8863c0ed-7dee-43e6-8859-5fcbd3b8dca2_202206280032406775_police-w-2.jpg', 12, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (24, 0, CAST(N'2022-06-28T00:32:40.6794508' AS DateTime2), NULL, NULL, N'5ff8fd6c-20f7-4bce-8f76-2e4978791a25_202206280032406786_police-w-3.jpg', 12, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (25, 0, CAST(N'2022-06-28T01:16:14.4221271' AS DateTime2), NULL, NULL, N'dd963229-0c31-457e-931e-6170a8daede8_202206280116144215_garmin-7.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (26, 0, CAST(N'2022-06-28T01:16:14.3729758' AS DateTime2), NULL, NULL, N'34f9008e-2199-4741-98e3-c79e2e4da819_202206280116143718_garmin-2.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (27, 0, CAST(N'2022-06-28T01:16:14.4187466' AS DateTime2), NULL, NULL, N'd13b113d-da6d-4e9d-ae1f-7f1bfcf3921f_202206280116143730_garmin-3.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (28, 0, CAST(N'2022-06-28T01:16:14.4200442' AS DateTime2), NULL, NULL, N'6e4e0d58-1214-4c83-aa7a-948d56bd17f8_202206280116144187_garmin-4.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (29, 0, CAST(N'2022-06-28T01:16:14.4207947' AS DateTime2), NULL, NULL, N'b280fd80-171a-4661-b0d2-05354622734f_202206280116144200_garmin-5.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (30, 0, CAST(N'2022-06-28T01:16:14.4215324' AS DateTime2), NULL, NULL, N'1fc80729-6586-46c8-9954-550f4f29b834_202206280116144208_garmin-6.jpg', 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (31, 0, CAST(N'2022-06-28T02:03:27.1465937' AS DateTime2), NULL, NULL, N'8f8b6b51-ac74-4197-b632-9fc915292d04_202206280203271457_aviator-2.jpg', 14, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (32, 0, CAST(N'2022-06-28T02:03:27.1844731' AS DateTime2), NULL, NULL, N'647b190f-d3f7-4bad-80ee-bce53e5bed37_202206280203271466_aviator-3.jpg', 14, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (33, 0, CAST(N'2022-06-28T02:27:32.2800697' AS DateTime2), NULL, NULL, N'1a7eddb0-d9fb-4d47-b1ab-7159321e6599_202206280227322788_mwc-2.jpg', 15, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (34, 0, CAST(N'2022-06-28T02:27:32.3052729' AS DateTime2), NULL, NULL, N'05efa6cd-f11a-4cda-ba52-37597df02ae3_202206280227322801_mwc-3.jpg', 15, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (35, 0, CAST(N'2022-06-28T02:27:32.3063367' AS DateTime2), NULL, NULL, N'87dc646c-2b79-470a-af91-18b5e2b65eba_202206280227323053_mwc-4.jpg', 15, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (36, 0, CAST(N'2022-06-28T02:46:20.2456020' AS DateTime2), NULL, NULL, N'e0fbad19-92ed-4b2a-b1ad-786cb0075be2_202206280246202445_nurse-2.jpg', 16, NULL)
INSERT [dbo].[ProductImages] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [ProductId], [RestoredAt]) VALUES (37, 0, CAST(N'2022-06-30T12:06:16.0188999' AS DateTime2), NULL, NULL, N'f75e8cc3-35f5-4e5d-b617-919ddc579609_202206301206160175_citizen-2.jpg', 17, NULL)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (3, 0, CAST(N'2022-06-25T11:24:00.2011105' AS DateTime2), CAST(N'2022-06-27T01:23:26.2690640' AS DateTime2), NULL, N'DS Action Diver', N'24e2d627-f2f7-447b-92d5-ff428c488c46_202206251124001957_certina-main.jpg', 1300.0000, 1250.0000, 30.0000, 50, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 13, 1, 2, 3, 1, 0, NULL, NULL, 0, NULL, 2)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (4, 0, CAST(N'2022-06-25T13:31:17.8837399' AS DateTime2), NULL, NULL, N'Prospex 1959 Alpinist Modern Re-interpretation', N'd4804119-8aa5-4e70-b76e-2f9fae4cccfc_202206251331178791_seiko-main.jpg', 1405.0000, 1399.0000, 35.0000, 41, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 8, 1, 2, NULL, 1, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (5, 0, CAST(N'2022-06-25T13:52:12.0335064' AS DateTime2), NULL, NULL, N'PRX', N'827f4ea7-a98a-4f02-800c-55776b261230_202206251352120303_tissot-main.jpg', 900.0000, NULL, 25.0000, 18, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1, 1, 2, NULL, 0, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (6, 0, CAST(N'2022-06-25T14:02:33.3700498' AS DateTime2), NULL, NULL, N'DS Caimano Titanium', N'e1309a30-b3c2-47df-82f7-1c55ed0bdba4_202206251402333675_certina-1.jpg', 500.0000, NULL, 15.0000, 30, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 13, 1, 2, NULL, 0, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (7, 0, CAST(N'2022-06-27T00:57:35.0823678' AS DateTime2), NULL, NULL, N'Darci', N'21038867-e1f0-4cbc-903f-03a917a0da74_202206270057350789_mk-main.jpg', 300.0000, NULL, 9.0000, 30, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 11, 1, 2, NULL, 0, 0, NULL, NULL, 0, NULL, 2)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (8, 0, CAST(N'2022-06-27T01:39:23.4596492' AS DateTime2), NULL, NULL, N'Pyper', N'89e96218-dffd-4b5d-afab-4e3a227e6f1c_202206270139234558_mk-main.jpg', 290.0000, NULL, 6.0000, 33, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 11, 1, 2, NULL, 1, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (9, 0, CAST(N'2022-06-27T02:14:42.6740010' AS DateTime2), CAST(N'2022-07-01T20:16:28.2467932' AS DateTime2), CAST(N'2022-06-27T18:50:28.0103419' AS DateTime2), N'T-Touch Connect Solar', N'777448ce-fd68-48ea-ab68-dc276bf80394_202206270214426675_tissot-main.jpg', 1200.0000, 1155.0000, 14.0000, 25, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1, 3, 1, NULL, 1, 1, N'59d3a051-9411-441e-b92c-a755095e597b_202206270400276590_slide-1.png', N'7ff2c4ec-6281-4679-ae6f-827814b187c4_202206270349146403_1.jpg', 1, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (10, 0, CAST(N'2022-06-27T23:28:51.3309029' AS DateTime2), NULL, NULL, N'Bridgeport Mechanical Skeleton', N'52cf561e-54f6-4c8a-b12f-f044e19c0d55_202206272328513260_tissot-pocket-main.jpg', 400.0000, NULL, 16.0000, 15, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1, 1, 2, 7, 1, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (11, 0, CAST(N'2022-06-28T00:19:48.4402864' AS DateTime2), CAST(N'2022-06-28T00:30:10.3302569' AS DateTime2), NULL, N'Rotor', N'9bbe4270-4461-453a-bb34-845e1873acf9_202206280019484361_police-main.jpg', 275.0000, NULL, 10.0000, 56, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 16, 2, 2, 2, 1, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (12, 0, CAST(N'2022-06-28T00:32:40.6794662' AS DateTime2), CAST(N'2022-06-28T00:34:43.4711529' AS DateTime2), NULL, N'Kapaa', N'179e2d72-9b9d-4464-81fd-6932d4215e67_202206280034434700_police-w-main.jpg', 265.0000, NULL, 10.0000, 10, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 16, 1, 2, 2, 0, 0, NULL, NULL, 0, NULL, 2)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (13, 0, CAST(N'2022-06-28T01:16:14.4223354' AS DateTime2), CAST(N'2022-07-06T10:01:09.0947657' AS DateTime2), CAST(N'2022-07-05T19:09:14.5878332' AS DateTime2), N'Enduro', N'ab2cf773-c72f-4515-9e58-6218f89e1dd2_202206280116143685_garmin-main.jpg', 1800.0000, NULL, 20.0000, 31, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 15, 5, 1, 6, 0, 0, NULL, NULL, 0, NULL, 3)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (14, 0, CAST(N'2022-06-28T02:03:27.1846744' AS DateTime2), NULL, NULL, N'Douglas Day-Date', N'a67d7687-7fa2-4b8f-9b4b-7e7825437f5f_202206280203271428_aviator-main.jpg', 3300.0000, 2800.0000, 30.0000, 16, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 17, 1, 2, 4, 1, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (15, 0, CAST(N'2022-06-28T02:27:32.3064114' AS DateTime2), CAST(N'2022-06-28T02:30:38.0840912' AS DateTime2), NULL, N'GG-W-113', N'170bf564-d0a7-4a44-a5b9-5b9f46cb2003_202206280230380824_mwc-main.jpg', 1555.0000, 1222.0000, 12.0000, 21, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 18, 1, 2, 1, 0, 0, NULL, NULL, 0, NULL, 1)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (16, 0, CAST(N'2022-06-28T02:46:20.2456165' AS DateTime2), NULL, NULL, N'Open Face L554 C Pendent', N'1702b5a6-2052-4121-8076-f9698faea26f_202206280246202406_nurse-main.jpg', 1500.0000, 1399.0000, 14.0000, 20, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 19, 1, 2, 5, 0, 0, NULL, NULL, 0, NULL, 2)
INSERT [dbo].[Products] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [MainImage], [Price], [DiscountPrice], [ExTax], [Count], [Description], [BrandId], [DisplayId], [PowerSourceId], [SpecialTypeId], [IsNewArrival], [ShareOnHomeSlide], [SlideImage], [PosterImage], [ShareAsPoster], [RestoredAt], [Gender]) VALUES (17, 0, CAST(N'2022-06-30T12:06:16.0199534' AS DateTime2), CAST(N'2022-07-06T10:00:17.1113462' AS DateTime2), CAST(N'2022-06-30T13:59:04.3265143' AS DateTime2), N'Promaster Dive Automatic', N'1b7b510d-d0f8-4e7d-bb7a-720edf6d53c5_202206301206160157_citizen-main.jpg', 666.0000, 650.0000, 22.0000, 14, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 7, 1, 2, 3, 0, 0, NULL, N'dc276236-d1bb-4ab0-8e4d-066b0d055c7a_202206301206160190_citizen-poster.jpg', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTags] ON 

INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (5, 4, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (6, 5, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (7, 6, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (10, 7, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (11, 3, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (12, 3, 4)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (13, 3, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (14, 8, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (15, 8, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (36, 11, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (39, 12, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (40, 12, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (41, 13, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (42, 14, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (44, 15, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (45, 16, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (51, 9, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (52, 9, 4)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (53, 9, 2)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (60, 17, 1)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (61, 17, 4)
INSERT [dbo].[ProductTags] ([Id], [ProductId], [TagId]) VALUES (62, 17, 2)
SET IDENTITY_INSERT [dbo].[ProductTags] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (44, 0, CAST(N'2022-07-08T12:51:03.9587645' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Good', 4, 8, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (45, 0, CAST(N'2022-07-08T12:51:16.7672597' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Super', 5, 9, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (46, 0, CAST(N'2022-07-08T12:51:27.9597436' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Not bad', 2, 10, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (47, 0, CAST(N'2022-07-08T12:51:48.3668407' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Great gift for policemen', 4, 11, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (48, 0, CAST(N'2022-07-08T12:52:15.1066146' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Aviator style', 3, 14, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (49, 0, CAST(N'2022-07-08T12:52:28.9593783' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Good one', 2, 3, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (50, 0, CAST(N'2022-07-08T12:52:38.0029464' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Perfect', 5, 4, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (51, 0, CAST(N'2022-07-08T12:53:43.2288737' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Garmin is great brand', 5, 13, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (52, 0, CAST(N'2022-07-08T12:53:54.4649332' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Not good', 2, 12, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (53, 0, CAST(N'2022-07-08T12:54:11.5353682' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Michael Kors is good option', 3, 7, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (54, 0, CAST(N'2022-07-08T12:54:52.2567165' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'P E R F E C T', 5, 6, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (55, 0, CAST(N'2022-07-08T12:55:17.4813791' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'Tissot is good', 4, 5, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (56, 0, CAST(N'2022-07-08T12:55:35.4294500' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'I didn''t like', 2, 17, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (57, 0, CAST(N'2022-07-08T12:55:58.4094853' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'For doctors', 4, 16, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (58, 0, CAST(N'2022-07-08T12:56:15.2395244' AS DateTime2), NULL, NULL, N'kamil750', N'kamil-k750@mail.ru', N'For military', 4, 15, NULL, N'eba78b68-474f-4362-bb71-ab802f952700')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (59, 0, CAST(N'2022-07-08T12:59:27.3511709' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Usable', 3, 15, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (60, 0, CAST(N'2022-07-08T13:00:26.5875496' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Not good', 2, 16, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (61, 0, CAST(N'2022-07-08T13:00:51.9230350' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Goood', 4, 17, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (62, 0, CAST(N'2022-07-08T13:01:09.6023594' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Liked', 3, 5, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (63, 0, CAST(N'2022-07-08T13:01:21.7206403' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'GREAT', 5, 6, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (64, 0, CAST(N'2022-07-08T13:01:47.9075416' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Super', 5, 7, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (65, 0, CAST(N'2022-07-08T13:02:04.5143552' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Not bad', 3, 12, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (66, 0, CAST(N'2022-07-08T13:02:21.3219927' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'SUPER', 5, 13, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (67, 0, CAST(N'2022-07-08T13:03:10.0434056' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Different & Great', 5, 4, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (68, 0, CAST(N'2022-07-08T13:03:45.1466593' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'It''s super dive watch', 4, 3, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (69, 0, CAST(N'2022-07-08T13:03:59.6474606' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Good', 4, 14, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (70, 0, CAST(N'2022-07-08T13:04:17.8889315' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Police watches', 5, 11, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (71, 0, CAST(N'2022-07-08T13:04:38.4875921' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Tissot is great brand', 5, 10, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (72, 0, CAST(N'2022-07-08T13:04:55.3515324' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Love', 4, 9, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
INSERT [dbo].[Reviews] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Name], [Email], [Comment], [Star], [ProductId], [RestoredAt], [AppUserId]) VALUES (73, 0, CAST(N'2022-07-08T13:05:34.4025555' AS DateTime2), NULL, NULL, N'tester1', N'web.developer.kamil@gmail.com', N'Simple but good. My choice!', 5, 8, NULL, N'706e1bd4-551f-4bd3-aa63-394d7886e3ac')
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[ServicePolicies] ON 

INSERT [dbo].[ServicePolicies] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [Title], [Description], [RestoredAt]) VALUES (1, 0, NULL, CAST(N'2022-06-27T04:43:27.8489141' AS DateTime2), NULL, N'customer-service.png', N'Customer Servcies', N'Top notch customer service', NULL)
INSERT [dbo].[ServicePolicies] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [Title], [Description], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'store.png', N'Pickup At Any Store', N'Pickup at any store if you want', NULL)
INSERT [dbo].[ServicePolicies] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [Title], [Description], [RestoredAt]) VALUES (3, 0, NULL, CAST(N'2022-06-27T04:43:22.4625389' AS DateTime2), NULL, N'secure-payment.png', N'Secured Payment', N'We accept all major credit cards', NULL)
INSERT [dbo].[ServicePolicies] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Image], [Title], [Description], [RestoredAt]) VALUES (4, 0, NULL, CAST(N'2022-06-27T04:43:17.3797198' AS DateTime2), CAST(N'2022-06-30T11:02:13.4087736' AS DateTime2), N'free-return.png', N'Free Returns', N'30-days free return policy', CAST(N'2022-06-30T11:02:16.5423289' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ServicePolicies] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Logo], [Offer], [Phone2], [Email1], [Email2], [Address], [Facebook], [Instagram], [Twitter], [RestoredAt], [SupportPhone], [SupportText]) VALUES (1, 0, NULL, CAST(N'2022-06-29T14:39:12.4032178' AS DateTime2), NULL, N'logo.png', N'Marketo Ecommerce always free delivery', N'+994709980919', N'marketo@gmail.com', N'admin@marketo.com', N'1418 Riverwood Drive, Suite 3245 Cottonwood, CA 96052, United States', N'https://www.facebook.com/quliyev039', N'https://www.instagram.com/quliyev_039', N'https://www.twitter.com/KamilGuliyev', NULL, N'+994123456789', N'Please don''t hesitate to contact us if you need further information.')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[SpecialTypes] ON 

INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'Military watches', N'8d823257-4e43-417b-a61f-6e1a2c1fca34_202206221828047281_1.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'Police watches', N'f972c5fe-5ef9-4640-9fd4-e160df1fc84d_202206221827592416_2.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'Dive watches', N'8cb4c6a6-e871-4c20-a01c-dad409dca3d8_202206221827522520_3.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Pilot watches', N'040823f2-ac56-4310-9cc3-c6a72b909199_202206221827455424_8.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (5, 0, NULL, NULL, NULL, N'Nurse watches', N'50b23373-5ec6-4df9-bfa9-6469056abbfb_202206221827372388_9.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (6, 0, NULL, NULL, NULL, N'Triathlon watches', N'd133715d-9c9a-4378-974e-098c68831802_202206221827312434_10.png', 1, NULL)
INSERT [dbo].[SpecialTypes] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [Image], [IsShared], [RestoredAt]) VALUES (7, 0, NULL, NULL, NULL, N'Pocket watches', N'ec74021e-6a69-4b06-b294-04a9ef7f2a36_202206221827156904_4.png', 1, NULL)
SET IDENTITY_INSERT [dbo].[SpecialTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (1, 0, NULL, NULL, NULL, N'StainlessSteel', NULL)
INSERT [dbo].[Tags] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (2, 0, NULL, NULL, NULL, N'WristWatch', NULL)
INSERT [dbo].[Tags] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (3, 0, NULL, NULL, NULL, N'LimitedEdition', NULL)
INSERT [dbo].[Tags] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (4, 0, NULL, NULL, NULL, N'Waterproof', NULL)
INSERT [dbo].[Tags] ([Id], [IsDeleted], [CreatedAt], [UpdatedAt], [DeletedAt], [Title], [RestoredAt]) VALUES (5, 0, CAST(N'2022-06-25T20:09:55.7050494' AS DateTime2), NULL, NULL, N'Anniversary', NULL)
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 27.12.2022 20:53:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 27.12.2022 20:53:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompareLists_AppUserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_CompareLists_AppUserId] ON [dbo].[CompareLists]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompareLists_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_CompareLists_ProductId] ON [dbo].[CompareLists]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_ProductId] ON [dbo].[OrderItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_AppUserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_AppUserId] ON [dbo].[Orders]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductColours_ColourId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductColours_ColourId] ON [dbo].[ProductColours]
(
	[ColourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductColours_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductColours_ProductId] ON [dbo].[ProductColours]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductFeatures_FeatureId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductFeatures_FeatureId] ON [dbo].[ProductFeatures]
(
	[FeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductFeatures_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductFeatures_ProductId] ON [dbo].[ProductFeatures]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductId] ON [dbo].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_BrandId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Products_BrandId] ON [dbo].[Products]
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_DisplayId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Products_DisplayId] ON [dbo].[Products]
(
	[DisplayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_PowerSourceId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Products_PowerSourceId] ON [dbo].[Products]
(
	[PowerSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SpecialTypeId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Products_SpecialTypeId] ON [dbo].[Products]
(
	[SpecialTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductTags_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductTags_ProductId] ON [dbo].[ProductTags]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductTags_TagId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ProductTags_TagId] ON [dbo].[ProductTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reviews_AppUserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_AppUserId] ON [dbo].[Reviews]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ProductId] ON [dbo].[Reviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ShoppingCarts_AppUserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCarts_AppUserId] ON [dbo].[ShoppingCarts]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCarts_ColourId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCarts_ColourId] ON [dbo].[ShoppingCarts]
(
	[ColourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCarts_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCarts_ProductId] ON [dbo].[ShoppingCarts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlists_AppUserId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_AppUserId] ON [dbo].[Wishlists]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlists_ProductId]    Script Date: 27.12.2022 20:53:45 ******/
CREATE NONCLUSTERED INDEX [IX_Wishlists_ProductId] ON [dbo].[Wishlists]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdsBanners] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsShared]
GO
ALTER TABLE [dbo].[FAQs] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsShared]
GO
ALTER TABLE [dbo].[ProductColours] ADD  DEFAULT ((0)) FOR [Count]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsNewArrival]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ShareOnHomeSlide]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ShareAsPoster]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT (N'') FOR [SupportPhone]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CompareLists]  WITH CHECK ADD  CONSTRAINT [FK_CompareLists_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CompareLists] CHECK CONSTRAINT [FK_CompareLists_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[CompareLists]  WITH CHECK ADD  CONSTRAINT [FK_CompareLists_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[CompareLists] CHECK CONSTRAINT [FK_CompareLists_Products_ProductId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[ProductColours]  WITH CHECK ADD  CONSTRAINT [FK_ProductColours_Colours_ColourId] FOREIGN KEY([ColourId])
REFERENCES [dbo].[Colours] ([Id])
GO
ALTER TABLE [dbo].[ProductColours] CHECK CONSTRAINT [FK_ProductColours_Colours_ColourId]
GO
ALTER TABLE [dbo].[ProductColours]  WITH CHECK ADD  CONSTRAINT [FK_ProductColours_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductColours] CHECK CONSTRAINT [FK_ProductColours_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Features_FeatureId] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Features] ([Id])
GO
ALTER TABLE [dbo].[ProductFeatures] CHECK CONSTRAINT [FK_ProductFeatures_Features_FeatureId]
GO
ALTER TABLE [dbo].[ProductFeatures]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductFeatures] CHECK CONSTRAINT [FK_ProductFeatures_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands_BrandId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Displays_DisplayId] FOREIGN KEY([DisplayId])
REFERENCES [dbo].[Displays] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Displays_DisplayId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_PowerSources_PowerSourceId] FOREIGN KEY([PowerSourceId])
REFERENCES [dbo].[PowerSources] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_PowerSources_PowerSourceId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SpecialTypes_SpecialTypeId] FOREIGN KEY([SpecialTypeId])
REFERENCES [dbo].[SpecialTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SpecialTypes_SpecialTypeId]
GO
ALTER TABLE [dbo].[ProductTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductTags_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductTags] CHECK CONSTRAINT [FK_ProductTags_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[ProductTags] CHECK CONSTRAINT [FK_ProductTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products_ProductId]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCarts_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_ShoppingCarts_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCarts_Colours_ColourId] FOREIGN KEY([ColourId])
REFERENCES [dbo].[Colours] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_ShoppingCarts_Colours_ColourId]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCarts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_ShoppingCarts_Products_ProductId]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_Products_ProductId]
GO
USE [master]
GO
