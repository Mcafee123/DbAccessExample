/****** Object:  Schema [CockpitSB]    Script Date: 12.05.17 11:22:27 ******/
CREATE SCHEMA [CockpitSB]
GO
/****** Object:  Schema [Navision]    Script Date: 12.05.17 11:22:27 ******/
CREATE SCHEMA [Navision]
GO
/****** Object:  Schema [Param]    Script Date: 12.05.17 11:22:28 ******/
CREATE SCHEMA [Param]
GO
/****** Object:  Table [CockpitSB].[Datei]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Datei](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateiName] [nvarchar](255) NOT NULL,
	[DateiGroesseKB] [int] NOT NULL,
	[DateiTyp] [int] NOT NULL,
	[DateiErweiterung] [nvarchar](255) NOT NULL,
	[Bezeichnung] [nvarchar](255) NOT NULL,
	[DateiInhalt] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_CockpitSB_Datei] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Dissertation]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Dissertation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[Titel] [nvarchar](2000) NOT NULL,
	[MedizinFakultaet] [nvarchar](255) NULL,
	[DatumDoktorTitel] [date] NULL,
	[Bemerkungen] [nvarchar](4000) NULL,
	[DateiId] [int] NULL,
 CONSTRAINT [PK_CockpitSB_Dissertation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Dossier]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Dossier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[BearbeiterBenutzerId] [int] NULL,
	[RevisionId] [int] NULL,
	[DossierStatus] [int] NOT NULL,
	[Dringend] [bit] NOT NULL,
	[Typ] [int] NOT NULL,
	[AblageortId] [int] NULL,
	[KandidatText] [nvarchar](4000) NULL,
	[ErstelltDatum] [smalldatetime] NOT NULL,
	[ModifiziertDatum] [smalldatetime] NOT NULL,
	[ModifiziertBenutzerId] [int] NOT NULL,
	[GesuchEingangDatum] [smalldatetime] NULL,
	[PosteingangDatum] [smalldatetime] NULL,
	[UlaAngefordertDatum] [smalldatetime] NULL,
	[UlaEingegangenDatum] [smalldatetime] NULL,
	[AnTitelkommissionDatum] [smalldatetime] NULL,
	[Bemerkungen] [nvarchar](4000) NULL,
 CONSTRAINT [PK_CockpitSB_Dossier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[DossierVerlauf]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[DossierVerlauf](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DossierId] [int] NOT NULL,
	[Zeitstempel] [smalldatetime] NOT NULL,
	[Typ] [int] NOT NULL,
	[DossierStatusAlt] [int] NULL,
	[DossierStatusNeu] [int] NULL,
	[Text] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_CockpitSB_DossierVerlauf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[HausarztZiele]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[HausarztZiele](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[LikertSkalaId] [int] NOT NULL,
	[Bewertung] [int] NOT NULL,
	[Bemerkung] [nvarchar](4000) NULL,
	[IstVerifiziert] [bit] NOT NULL,
 CONSTRAINT [PK_CockpitSB_HausarztZiele] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Periode]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Periode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[WBStaetteId] [int] NOT NULL,
	[Typ] [tinyint] NOT NULL,
	[DatumStart] [date] NULL,
	[DatumEnde] [date] NULL,
	[Bemerkungen] [nvarchar](4000) NULL,
 CONSTRAINT [PK_CockpitSB_Periode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[PeriodeAbsenz]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[PeriodeAbsenz](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[AbsenzTypId] [int] NOT NULL,
	[AngabeIn] [int] NOT NULL,
	[ArbeitsPensum] [int] NOT NULL,
	[ProzenteAbwesenheit] [int] NOT NULL,
	[AbsenzTage] [numeric](6, 2) NULL,
	[DatumBegin] [date] NULL,
	[DatumEnde] [date] NULL,
	[NettoAbsenzTage] [numeric](6, 2) NOT NULL,
 CONSTRAINT [PK_CockpitSB_PeriodeAbsenz] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[PeriodeAbsenzV1]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[PeriodeAbsenzV1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[TageKrankheit] [numeric](6, 2) NOT NULL,
	[TageMutterschaft] [numeric](6, 2) NOT NULL,
	[TageMilitaer] [numeric](6, 2) NOT NULL,
	[TageUnbezahlt] [numeric](6, 2) NOT NULL,
	[TageAndere] [numeric](6, 2) NOT NULL,
	[Bemerkungen] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_CockpitSB_PeriodeAbsenzV1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[PeriodeEintrag]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[PeriodeEintrag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[Typ] [tinyint] NOT NULL,
	[DatumStart] [date] NULL,
	[DatumEnde] [date] NULL,
	[PensumProzent] [int] NOT NULL,
	[MonateNetto] [decimal](4, 2) NOT NULL,
	[MonateAnrechnen] [decimal](4, 2) NOT NULL,
	[VerrechnungsArt] [int] NOT NULL,
	[TaetigkeitArtId] [int] NOT NULL,
	[StrukturHauptteilId] [int] NOT NULL,
	[StrukturElementId] [int] NULL,
	[StrukturRotationId] [int] NULL,
 CONSTRAINT [PK_CockpitSB_PeriodeEintrag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[PeriodeTaetigkeit]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[PeriodeTaetigkeit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[TaetigkeitArtId] [int] NOT NULL,
	[TaetigkeitRolleId] [int] NOT NULL,
	[PensumProzente] [int] NOT NULL,
	[DatumStart] [date] NULL,
	[DatumEnde] [date] NULL,
 CONSTRAINT [PK_CockpitSB_PeriodeTaetigkeit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Prozedur]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Prozedur](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[ProzedurId] [int] NOT NULL,
	[Anzahl] [int] NOT NULL,
	[Datum] [date] NOT NULL,
	[Bemerkung] [nvarchar](255) NULL,
	[IstVerifiziert] [bit] NOT NULL,
 CONSTRAINT [PK_CockpitSB_Prozedur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[ProzedurSummen]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[ProzedurSummen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[ProzedurId] [int] NOT NULL,
	[SummeInPeriode] [int] NOT NULL,
 CONSTRAINT [PK_CockpitSB_ProzedurSummen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[ProzedurSummenEintrag]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[ProzedurSummenEintrag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodeId] [int] NOT NULL,
	[ProzedurEintragId] [int] NOT NULL,
	[SummeFuerEintrag] [int] NOT NULL,
 CONSTRAINT [PK_CockpitSB_ProzedurSummenEintrag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Pruefung]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Pruefung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[Bezeichnung] [nvarchar](255) NOT NULL,
	[Datum] [date] NOT NULL,
	[Bestanden] [bit] NOT NULL,
 CONSTRAINT [PK_CockpitSB_Pruefung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Publikation]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Publikation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[Titel] [nvarchar](2000) NOT NULL,
	[Autor] [nvarchar](255) NOT NULL,
	[PeerReviewed] [bit] NOT NULL,
	[AutorTyp] [int] NOT NULL,
	[Zeitschrift] [nvarchar](255) NULL,
	[AusgabeJahr] [int] NULL,
	[AusgabeNummer] [nvarchar](255) NULL,
	[AusgabeSeite] [nvarchar](60) NULL,
	[DateiId] [int] NULL,
 CONSTRAINT [PK_CockpitSB_Publikation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[Veranstaltung]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[Veranstaltung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[DatumBeginn] [date] NOT NULL,
	[DatumEnde] [date] NULL,
	[Typ] [int] NOT NULL,
	[Bezeichnung] [nvarchar](2000) NOT NULL,
	[Ort] [nvarchar](255) NOT NULL,
	[Inhalte] [nvarchar](4000) NOT NULL,
	[Credits] [int] NULL,
	[AnzahlTage] [int] NULL,
 CONSTRAINT [PK_CockpitSB_Veranstaltung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CockpitSB].[VortragPoster]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CockpitSB].[VortragPoster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArztBenutzerId] [int] NOT NULL,
	[AnlassName] [nvarchar](255) NOT NULL,
	[AnlassOrt] [nvarchar](255) NOT NULL,
	[DatumBeginn] [date] NOT NULL,
	[DatumEnde] [date] NOT NULL,
	[Typ] [int] NOT NULL,
	[Inhalte] [nvarchar](4000) NOT NULL,
	[Credits] [int] NULL,
	[DateiId] [int] NULL,
 CONSTRAINT [PK_CockpitSB_VortragPoster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AbsenzTyp]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbsenzTyp](
	[Id] [int] NOT NULL,
	[TextDE] [nvarchar](255) NOT NULL,
	[TextFR] [nvarchar](255) NOT NULL,
	[TextIT] [nvarchar](255) NOT NULL,
	[TextEN] [nvarchar](255) NOT NULL,
	[TextKurzDE] [nvarchar](255) NOT NULL,
	[TextKurzFR] [nvarchar](255) NOT NULL,
	[TextKurzIT] [nvarchar](255) NOT NULL,
	[TextKurzEN] [nvarchar](255) NOT NULL,
	[BeschreibungDE] [nvarchar](255) NOT NULL,
	[BeschreibungFR] [nvarchar](255) NOT NULL,
	[BeschreibungIT] [nvarchar](255) NOT NULL,
	[BeschreibungEN] [nvarchar](255) NOT NULL,
	[RegelungTextDE] [nvarchar](255) NOT NULL,
	[RegelungTextFR] [nvarchar](255) NOT NULL,
	[RegelungTextIT] [nvarchar](255) NOT NULL,
	[RegelungTextEN] [nvarchar](255) NOT NULL,
	[SummierungsArt] [int] NOT NULL,
	[SchwelleInTagen] [int] NOT NULL,
	[AktionUebertretung] [int] NOT NULL,
 CONSTRAINT [PK_dbo_AbsenzTyp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DossierAblageort]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DossierAblageort](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Typ] [int] NOT NULL,
	[TextDE] [nvarchar](4000) NOT NULL,
	[TextFR] [nvarchar](4000) NOT NULL,
	[TextIT] [nvarchar](4000) NOT NULL,
	[TextEN] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_dbo_DossierAblageort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LikertSkala]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikertSkala](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo_LikertSkala] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LikertSkalaElement]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikertSkalaElement](
	[Id] [int] NOT NULL,
	[LikertSkalaId] [int] NOT NULL,
	[NameDE] [nvarchar](255) NOT NULL,
	[NameFR] [nvarchar](255) NOT NULL,
	[NameIT] [nvarchar](255) NOT NULL,
	[NameEN] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo_LikertSkalaElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prozedur]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prozedur](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Typ] [int] NOT NULL,
	[NameDE] [nvarchar](2000) NOT NULL,
	[NameFR] [nvarchar](2000) NOT NULL,
	[NameIT] [nvarchar](2000) NOT NULL,
	[NameEN] [nvarchar](2000) NOT NULL,
	[SuchWorte] [nvarchar](4000) NOT NULL,
	[FremdId] [int] NULL,
	[WBProgrammId] [int] NULL,
 CONSTRAINT [PK_dbo_Prozedur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProzedurParentMapping]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProzedurParentMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProzedurId] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_dbo_ProzedurParentMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchemaVersions]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchemaVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScriptName] [nvarchar](255) NOT NULL,
	[Applied] [datetime] NOT NULL,
 CONSTRAINT [PK_SchemaVersions_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaetigkeitArt]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaetigkeitArt](
	[Id] [int] NOT NULL,
	[TextDE] [nvarchar](60) NOT NULL,
	[TextFR] [nvarchar](60) NOT NULL,
	[TextIT] [nvarchar](60) NOT NULL,
	[TextEN] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_dbo_TaetigkeitArt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaetigkeitRolle]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaetigkeitRolle](
	[Id] [int] NOT NULL,
	[Typ] [int] NOT NULL,
	[TextDE] [nvarchar](255) NOT NULL,
	[TextFR] [nvarchar](255) NOT NULL,
	[TextIT] [nvarchar](255) NOT NULL,
	[TextEN] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo_TaetigkeitRolle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Navision].[Benutzer]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navision].[Benutzer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FMHId] [int] NOT NULL,
	[FMHMember] [bit] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Vorname] [nvarchar](255) NOT NULL,
	[Geschlecht] [tinyint] NOT NULL,
	[Sprache] [nvarchar](2) NULL,
	[Adresse1] [nvarchar](255) NOT NULL,
	[Adresse2] [nvarchar](255) NULL,
	[CoAdresse] [nvarchar](255) NULL,
	[Plz] [nvarchar](255) NULL,
	[Ort] [nvarchar](255) NULL,
	[EMail] [nvarchar](255) NULL,
	[Geburtsdatum] [date] NULL,
	[AusbildungDiplomLand] [nvarchar](255) NULL,
	[AusbildungDiplomOrt] [nvarchar](255) NULL,
	[AusbildungDiplomDatum] [date] NULL,
 CONSTRAINT [PK_Navision_Benutzer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Navision_Benutzer_FMHId] UNIQUE NONCLUSTERED 
(
	[FMHId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Navision].[WBKategorie]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navision].[WBKategorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavKategorieId] [int] NOT NULL,
	[NavProgrammId] [int] NOT NULL,
	[GueltigVon] [date] NOT NULL,
	[GueltigBis] [date] NOT NULL,
	[NameDE] [nvarchar](160) NOT NULL,
	[NameFR] [nvarchar](160) NOT NULL,
	[NameKurzDE] [nvarchar](30) NOT NULL,
	[NameKurzFR] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Navision_WBKategorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Navision_WBKategorie_KategorieId] UNIQUE NONCLUSTERED 
(
	[NavKategorieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Navision].[WBProgramm]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navision].[WBProgramm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavProgrammId] [int] NOT NULL,
	[NavDiplomId] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
 CONSTRAINT [PK_Navision_WBProgramm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Navision_WBProgramm_NavProgrammId] UNIQUE NONCLUSTERED 
(
	[NavProgrammId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Navision].[WBStaette]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navision].[WBStaette](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavDossierNr] [int] NOT NULL,
	[NavWBSId] [int] NOT NULL,
	[NavKategorieId] [int] NOT NULL,
	[GueltigVon] [date] NOT NULL,
	[GueltigBis] [date] NULL,
	[Adresszeile1] [nvarchar](255) NOT NULL,
	[Adresszeile2] [nvarchar](255) NULL,
	[Adresszeile3] [nvarchar](255) NULL,
	[Strasse] [nvarchar](255) NULL,
	[PLZ] [nvarchar](255) NOT NULL,
	[Ort] [nvarchar](255) NULL,
	[Kanton] [nvarchar](255) NULL,
	[Land] [nvarchar](255) NULL,
	[Telefon1] [nvarchar](255) NULL,
	[Telefon2] [nvarchar](255) NULL,
	[Telefon1Bemerkung] [nvarchar](255) NULL,
	[Telefon2Bemerkung] [nvarchar](255) NULL,
	[Typ] [tinyint] NOT NULL,
	[LeiterName] [nvarchar](255) NULL,
	[LeiterVorname] [nvarchar](255) NULL,
	[LeiterAnrede] [nvarchar](255) NULL,
	[LeiterBenutzerId] [int] NOT NULL,
	[AnerkennungsStatus] [int] NOT NULL,
 CONSTRAINT [PK_Navision_WBStaette] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Navision].[WBTitel]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navision].[WBTitel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavDiplomId] [int] NOT NULL,
	[NavTitelTypId] [tinyint] NOT NULL,
	[NameDE] [nvarchar](255) NOT NULL,
	[NameFR] [nvarchar](255) NOT NULL,
	[NameIT] [nvarchar](255) NOT NULL,
	[NameEN] [nvarchar](255) NOT NULL,
	[GueltigVon] [date] NOT NULL,
	[GueltigBis] [date] NOT NULL,
 CONSTRAINT [PK_Navision_WBTitel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Navision_WBTitel_NavDiplomId] UNIQUE NONCLUSTERED 
(
	[NavDiplomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[AnforderungsElement]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[AnforderungsElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SegmentVarianteId] [int] NOT NULL,
	[ElementTyp] [int] NOT NULL,
	[StrukturElementId] [int] NULL,
	[TaetigkeitId] [int] NULL,
	[MonateMin] [int] NOT NULL,
	[MonateMax] [int] NOT NULL,
	[StrukturRotationId] [int] NULL,
	[SummenAnforderungId] [int] NULL,
	[BedingungId] [int] NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Param_AnforderungsElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[FachRotation]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[FachRotation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FachRotationThemaId] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[BeschreibungDE] [nvarchar](4000) NOT NULL,
	[BeschreibungFR] [nvarchar](4000) NOT NULL,
	[RotationsTyp] [int] NOT NULL,
	[LikertSkalaId] [int] NULL,
	[AngabeMonate] [bit] NOT NULL,
	[AngabePensum] [bit] NOT NULL,
	[AngabeVonBis] [bit] NOT NULL,
	[AngabeBemerkung] [bit] NOT NULL,
 CONSTRAINT [PK_Param_FachRotation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[FachRotationOption]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[FachRotationOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FachRotationId] [int] NOT NULL,
	[BezeichnungDE] [nvarchar](1000) NOT NULL,
	[BezeichnungFR] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Param_FachRotationOption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[FachRotationThema]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[FachRotationThema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[BezeichnungDE] [nvarchar](1000) NOT NULL,
	[BezeichnungFR] [nvarchar](1000) NOT NULL,
	[Position] [int] NOT NULL,
	[EinfuehrungsTextDE] [nvarchar](4000) NULL,
	[AbschlussTextDE] [nvarchar](4000) NULL,
	[EinfuehrungsTextFR] [nvarchar](4000) NULL,
	[AbschlussTextFR] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Param_FachRotationThema] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Gutachten]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Gutachten](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[IstQuantitativesLZ] [bit] NOT NULL,
	[NachweisTyp] [int] NOT NULL,
	[AnforderungsText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Param_Gutachten] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Hilfsmittel]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Hilfsmittel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[LinkZuWBProgramm] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Param_Hilfsmittel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Hinweis]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Hinweis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HilfsmittelId] [int] NOT NULL,
	[HinweisText] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Param_Hinweis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ManuellePruefung]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ManuellePruefung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[Anweisung] [nvarchar](4000) NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Param_ManuellePruefung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ProzedurEintrag]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ProzedurEintrag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProzedurGruppeId] [int] NOT NULL,
	[Sichtbar] [bit] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[SpaltenAnzeigeFlag] [int] NOT NULL,
	[WertMin] [int] NULL,
	[WertMax] [int] NULL,
	[WertRichtwert] [int] NULL,
	[WertSollTotal] [int] NULL,
	[WertSollO] [int] NULL,
	[WertSollAI] [int] NULL,
	[WertSollA] [int] NULL,
 CONSTRAINT [PK_Param_Prozedur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ProzedurGruppe]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ProzedurGruppe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProzedurTabelleId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Position] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SpaltenAnzeigeFlag] [int] NOT NULL,
	[WertMin] [int] NULL,
	[WertMax] [int] NULL,
	[WertRichtwert] [int] NULL,
	[WertSollTotal] [int] NULL,
	[WertSollO] [int] NULL,
	[WertSollAI] [int] NULL,
	[WertSollA] [int] NULL,
 CONSTRAINT [PK_Param_ProzedurGruppe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ProzedurMapping]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ProzedurMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProzedurEintragId] [int] NOT NULL,
	[ProzedurId] [int] NOT NULL,
 CONSTRAINT [PK_Param_ProzedurMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ProzedurTabelle]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ProzedurTabelle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[ProzedurTyp] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Titel] [nvarchar](255) NOT NULL,
	[KopfText] [nvarchar](4000) NULL,
	[FussText] [nvarchar](4000) NULL,
	[TextRichtwert] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Param_ProzedurTabelle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Revision]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Revision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VersionId] [int] NOT NULL,
	[RevisionsDatum] [date] NOT NULL,
	[RevisionsNr] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[UebergangsTextArzt] [nvarchar](4000) NULL,
	[UebergangsTextSB] [nvarchar](4000) NULL,
	[UebergangRelevant] [int] NOT NULL,
	[WBORevisionId] [int] NOT NULL,
 CONSTRAINT [PK_Param_Revision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Param_Revision_RevisionsNr] UNIQUE NONCLUSTERED 
(
	[RevisionsNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[SammelObjekt]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[SammelObjekt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[HatHausarztZiele] [bit] NOT NULL,
	[TextPruefungen] [nvarchar](4000) NOT NULL,
	[TextPublikationen] [nvarchar](4000) NOT NULL,
	[TextKongresse] [nvarchar](4000) NOT NULL,
	[TextKurse] [nvarchar](4000) NOT NULL,
	[TextKurseAlsWBP] [nvarchar](4000) NOT NULL,
	[EnumKursBewertung] [int] NOT NULL,
	[EnumKongressBewertung] [int] NOT NULL,
	[TextKursBewertung] [nvarchar](4000) NULL,
	[TextKongressBewertung] [nvarchar](4000) NULL,
	[LinkZuKursRegelung] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Param_SammelObjekt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[SegmentVariante]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[SegmentVariante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StrukturSegmentId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[AnzahlMonate] [int] NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Param_SegmentVariante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Stellung]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Stellung](
	[Id] [int] NOT NULL,
	[VersionId] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[Selbststaendig] [bit] NOT NULL,
	[Kennung] [int] NOT NULL,
	[KurztextDE] [nvarchar](6) NOT NULL,
	[KurztextFR] [nvarchar](6) NOT NULL,
	[KurztextIT] [nvarchar](6) NOT NULL,
	[KurztextEN] [nvarchar](6) NOT NULL,
	[TextDE] [nvarchar](255) NOT NULL,
	[TextFR] [nvarchar](255) NOT NULL,
	[TextIT] [nvarchar](255) NOT NULL,
	[TextEN] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Param_Stellung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[StrukturElement]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[StrukturElement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[NameDE] [nvarchar](255) NOT NULL,
	[NameFR] [nvarchar](255) NOT NULL,
	[Bemerkung] [nvarchar](4000) NOT NULL,
	[MaxMonateTotal] [int] NULL,
	[MaxMonateHauptteil] [int] NULL,
	[ErfuelltRotationId] [int] NULL,
 CONSTRAINT [PK_Param_StrukturElement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[StrukturHauptteil]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[StrukturHauptteil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Param_StrukturHauptteil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[StrukturRotation]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[StrukturRotation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RevisionId] [int] NOT NULL,
	[Bezeichnung] [nvarchar](255) NOT NULL,
	[AnzahlMonate] [int] NOT NULL,
	[MitZeugnisErfuellbar] [bit] NOT NULL,
	[AngabeVonBis] [bit] NOT NULL,
	[AngabePensum] [bit] NOT NULL,
	[AngabeBemerkung] [bit] NOT NULL,
 CONSTRAINT [PK_Param_StrukturRotation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[StrukturSegment]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[StrukturSegment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StrukturHauptteilId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Param_StrukturSegment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[SummenAnforderung]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[SummenAnforderung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StrukturElementId] [int] NOT NULL,
	[TaetigkeitId] [int] NOT NULL,
	[StrukturHauptteilId] [int] NULL,
	[StrukturSegmentId] [int] NULL,
	[SummeMonate] [int] NOT NULL,
	[MaxMonate] [int] NOT NULL,
 CONSTRAINT [PK_Param_SummenAnforderung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[Version]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[Version](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WBTitelId] [int] NOT NULL,
	[WBProgrammId] [int] NOT NULL,
	[AusgabeDatum] [date] NOT NULL,
	[Inkraftsetzung] [date] NOT NULL,
	[Ausserkraftsetzung] [date] NULL,
	[Aktiv] [bit] NOT NULL,
 CONSTRAINT [PK_Param_Version] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[WBOLernziel]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[WBOLernziel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WBORevisionId] [int] NOT NULL,
	[TitelDE] [nvarchar](255) NOT NULL,
	[TitelFR] [nvarchar](255) NOT NULL,
	[InhaltDE] [nvarchar](4000) NOT NULL,
	[InhaltFR] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Param_WBOLernziel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[WBORevision]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[WBORevision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WBOVersionId] [int] NOT NULL,
	[RevisionsDatum] [date] NOT NULL,
	[LikertSkalaId] [int] NOT NULL,
	[EinfuehrungsTextDE] [nvarchar](4000) NULL,
	[EinfuehrungsTextFR] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Param_WBORevision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[WBOVersion]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[WBOVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AusgabeDatum] [date] NOT NULL,
	[Inkraftsetzung] [date] NOT NULL,
 CONSTRAINT [PK_Param_WBOVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Param].[ZeugnisMapping]    Script Date: 12.05.17 11:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Param].[ZeugnisMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WBTitelId] [int] NOT NULL,
	[WBProgrammId] [int] NOT NULL,
	[WBKategorieId] [int] NOT NULL,
	[StrukturElementId] [int] NOT NULL,
 CONSTRAINT [PK_Param_ZeugnisMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ((0)) FOR [TageKrankheit]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ((0)) FOR [TageMutterschaft]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ((0)) FOR [TageMilitaer]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ((0)) FOR [TageUnbezahlt]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ((0)) FOR [TageAndere]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] ADD  DEFAULT ('') FOR [Bemerkungen]
GO
ALTER TABLE [CockpitSB].[Veranstaltung] ADD  DEFAULT ('') FOR [Ort]
GO
ALTER TABLE [dbo].[LikertSkalaElement] ADD  DEFAULT ('') FOR [NameFR]
GO
ALTER TABLE [dbo].[LikertSkalaElement] ADD  DEFAULT ('') FOR [NameIT]
GO
ALTER TABLE [dbo].[LikertSkalaElement] ADD  DEFAULT ('') FOR [NameEN]
GO
ALTER TABLE [Navision].[WBStaette] ADD  DEFAULT (CONVERT([date],'9999-12-31')) FOR [GueltigBis]
GO
ALTER TABLE [Param].[Gutachten] ADD  DEFAULT ('') FOR [AnforderungsText]
GO
ALTER TABLE [Param].[Hilfsmittel] ADD  DEFAULT ('') FOR [LinkZuWBProgramm]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [TextPruefungen]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [TextPublikationen]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [TextKongresse]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [TextKurse]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [TextKurseAlsWBP]
GO
ALTER TABLE [Param].[SammelObjekt] ADD  DEFAULT ('') FOR [LinkZuKursRegelung]
GO
ALTER TABLE [Param].[StrukturSegment] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [Param].[Version] ADD  DEFAULT (CONVERT([date],'9999-12-31')) FOR [Ausserkraftsetzung]
GO
ALTER TABLE [CockpitSB].[Dissertation]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dissertation_CockpitSB_Datei] FOREIGN KEY([DateiId])
REFERENCES [CockpitSB].[Datei] ([Id])
GO
ALTER TABLE [CockpitSB].[Dissertation] CHECK CONSTRAINT [FK_CockpitSB_Dissertation_CockpitSB_Datei]
GO
ALTER TABLE [CockpitSB].[Dissertation]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dissertation_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Dissertation] CHECK CONSTRAINT [FK_CockpitSB_Dissertation_Navision_Benutzer]
GO
ALTER TABLE [CockpitSB].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dossier_AblageortId] FOREIGN KEY([AblageortId])
REFERENCES [dbo].[DossierAblageort] ([Id])
GO
ALTER TABLE [CockpitSB].[Dossier] CHECK CONSTRAINT [FK_CockpitSB_Dossier_AblageortId]
GO
ALTER TABLE [CockpitSB].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dossier_Arzt] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Dossier] CHECK CONSTRAINT [FK_CockpitSB_Dossier_Arzt]
GO
ALTER TABLE [CockpitSB].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dossier_Bearbeiter] FOREIGN KEY([BearbeiterBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Dossier] CHECK CONSTRAINT [FK_CockpitSB_Dossier_Bearbeiter]
GO
ALTER TABLE [CockpitSB].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Dossier_RevisionId] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [CockpitSB].[Dossier] CHECK CONSTRAINT [FK_CockpitSB_Dossier_RevisionId]
GO
ALTER TABLE [CockpitSB].[DossierVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_DossierVerlauf_CockpitSB_Dossier] FOREIGN KEY([DossierId])
REFERENCES [CockpitSB].[Dossier] ([Id])
GO
ALTER TABLE [CockpitSB].[DossierVerlauf] CHECK CONSTRAINT [FK_CockpitSB_DossierVerlauf_CockpitSB_Dossier]
GO
ALTER TABLE [CockpitSB].[HausarztZiele]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_HausarztZiele_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[HausarztZiele] CHECK CONSTRAINT [FK_CockpitSB_HausarztZiele_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[HausarztZiele]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_HausarztZiele_dbo_LikertSkala] FOREIGN KEY([LikertSkalaId])
REFERENCES [dbo].[LikertSkala] ([Id])
GO
ALTER TABLE [CockpitSB].[HausarztZiele] CHECK CONSTRAINT [FK_CockpitSB_HausarztZiele_dbo_LikertSkala]
GO
ALTER TABLE [CockpitSB].[Periode]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Periode_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Periode] CHECK CONSTRAINT [FK_CockpitSB_Periode_Navision_Benutzer]
GO
ALTER TABLE [CockpitSB].[Periode]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Periode_Navision_WBStaette] FOREIGN KEY([WBStaetteId])
REFERENCES [Navision].[WBStaette] ([Id])
GO
ALTER TABLE [CockpitSB].[Periode] CHECK CONSTRAINT [FK_CockpitSB_Periode_Navision_WBStaette]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenz]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeAbsenz_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenz] CHECK CONSTRAINT [FK_CockpitSB_PeriodeAbsenz_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenz]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeAbsenz_dbo_AbsenzTyp] FOREIGN KEY([AbsenzTypId])
REFERENCES [dbo].[AbsenzTyp] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenz] CHECK CONSTRAINT [FK_CockpitSB_PeriodeAbsenz_dbo_AbsenzTyp]
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeAbsenzV1_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeAbsenzV1] CHECK CONSTRAINT [FK_CockpitSB_PeriodeAbsenzV1_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeEintrag_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag] CHECK CONSTRAINT [FK_CockpitSB_PeriodeEintrag_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeEintrag_dbo_TaetigkeitArt] FOREIGN KEY([TaetigkeitArtId])
REFERENCES [dbo].[TaetigkeitArt] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag] CHECK CONSTRAINT [FK_CockpitSB_PeriodeEintrag_dbo_TaetigkeitArt]
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturElement] FOREIGN KEY([StrukturElementId])
REFERENCES [Param].[StrukturElement] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag] CHECK CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturElement]
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturHauptteil] FOREIGN KEY([StrukturHauptteilId])
REFERENCES [Param].[StrukturHauptteil] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag] CHECK CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturHauptteil]
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturRotation] FOREIGN KEY([StrukturRotationId])
REFERENCES [Param].[StrukturRotation] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeEintrag] CHECK CONSTRAINT [FK_CockpitSB_PeriodeEintrag_Param_StrukturRotation]
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit] CHECK CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_dbo_TaetigkeitArt] FOREIGN KEY([TaetigkeitArtId])
REFERENCES [dbo].[TaetigkeitArt] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit] CHECK CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_dbo_TaetigkeitArt]
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_dbo_TaetigkeitRolle] FOREIGN KEY([TaetigkeitRolleId])
REFERENCES [dbo].[TaetigkeitRolle] ([Id])
GO
ALTER TABLE [CockpitSB].[PeriodeTaetigkeit] CHECK CONSTRAINT [FK_CockpitSB_PeriodeTaetigkeit_dbo_TaetigkeitRolle]
GO
ALTER TABLE [CockpitSB].[Prozedur]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Prozedur_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[Prozedur] CHECK CONSTRAINT [FK_CockpitSB_Prozedur_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[Prozedur]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Prozedur_dbo_Prozedur] FOREIGN KEY([ProzedurId])
REFERENCES [dbo].[Prozedur] ([Id])
GO
ALTER TABLE [CockpitSB].[Prozedur] CHECK CONSTRAINT [FK_CockpitSB_Prozedur_dbo_Prozedur]
GO
ALTER TABLE [CockpitSB].[ProzedurSummen]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_ProzedurSummen_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[ProzedurSummen] CHECK CONSTRAINT [FK_CockpitSB_ProzedurSummen_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[ProzedurSummen]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_ProzedurSummen_dbo_Prozedur] FOREIGN KEY([ProzedurId])
REFERENCES [dbo].[Prozedur] ([Id])
GO
ALTER TABLE [CockpitSB].[ProzedurSummen] CHECK CONSTRAINT [FK_CockpitSB_ProzedurSummen_dbo_Prozedur]
GO
ALTER TABLE [CockpitSB].[ProzedurSummenEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_ProzedurSummenEintrag_CockpitSB_Periode] FOREIGN KEY([PeriodeId])
REFERENCES [CockpitSB].[Periode] ([Id])
GO
ALTER TABLE [CockpitSB].[ProzedurSummenEintrag] CHECK CONSTRAINT [FK_CockpitSB_ProzedurSummenEintrag_CockpitSB_Periode]
GO
ALTER TABLE [CockpitSB].[ProzedurSummenEintrag]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_ProzedurSummenEintrag_Param_ProzedurEintrag] FOREIGN KEY([ProzedurEintragId])
REFERENCES [Param].[ProzedurEintrag] ([Id])
GO
ALTER TABLE [CockpitSB].[ProzedurSummenEintrag] CHECK CONSTRAINT [FK_CockpitSB_ProzedurSummenEintrag_Param_ProzedurEintrag]
GO
ALTER TABLE [CockpitSB].[Pruefung]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Pruefung_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Pruefung] CHECK CONSTRAINT [FK_CockpitSB_Pruefung_Navision_Benutzer]
GO
ALTER TABLE [CockpitSB].[Publikation]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Publikation_CockpitSB_Datei] FOREIGN KEY([DateiId])
REFERENCES [CockpitSB].[Datei] ([Id])
GO
ALTER TABLE [CockpitSB].[Publikation] CHECK CONSTRAINT [FK_CockpitSB_Publikation_CockpitSB_Datei]
GO
ALTER TABLE [CockpitSB].[Publikation]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Publikation_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Publikation] CHECK CONSTRAINT [FK_CockpitSB_Publikation_Navision_Benutzer]
GO
ALTER TABLE [CockpitSB].[Veranstaltung]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_Veranstaltung_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[Veranstaltung] CHECK CONSTRAINT [FK_CockpitSB_Veranstaltung_Navision_Benutzer]
GO
ALTER TABLE [CockpitSB].[VortragPoster]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_VortragPoster_CockpitSB_Datei] FOREIGN KEY([DateiId])
REFERENCES [CockpitSB].[Datei] ([Id])
GO
ALTER TABLE [CockpitSB].[VortragPoster] CHECK CONSTRAINT [FK_CockpitSB_VortragPoster_CockpitSB_Datei]
GO
ALTER TABLE [CockpitSB].[VortragPoster]  WITH CHECK ADD  CONSTRAINT [FK_CockpitSB_VortragPoster_Navision_Benutzer] FOREIGN KEY([ArztBenutzerId])
REFERENCES [Navision].[Benutzer] ([Id])
GO
ALTER TABLE [CockpitSB].[VortragPoster] CHECK CONSTRAINT [FK_CockpitSB_VortragPoster_Navision_Benutzer]
GO
ALTER TABLE [dbo].[LikertSkalaElement]  WITH CHECK ADD  CONSTRAINT [FK_dbo_LikertSkalaElement_dbo_LikertSkala] FOREIGN KEY([LikertSkalaId])
REFERENCES [dbo].[LikertSkala] ([Id])
GO
ALTER TABLE [dbo].[LikertSkalaElement] CHECK CONSTRAINT [FK_dbo_LikertSkalaElement_dbo_LikertSkala]
GO
ALTER TABLE [dbo].[Prozedur]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Prozedur_Navision_WBProgramm] FOREIGN KEY([WBProgrammId])
REFERENCES [Navision].[WBProgramm] ([Id])
GO
ALTER TABLE [dbo].[Prozedur] CHECK CONSTRAINT [FK_dbo_Prozedur_Navision_WBProgramm]
GO
ALTER TABLE [dbo].[ProzedurParentMapping]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Prozedur_dbo_Prozedur_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Prozedur] ([Id])
GO
ALTER TABLE [dbo].[ProzedurParentMapping] CHECK CONSTRAINT [FK_dbo_Prozedur_dbo_Prozedur_ParentId]
GO
ALTER TABLE [dbo].[ProzedurParentMapping]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Prozedur_dbo_Prozedur_ProzedurId] FOREIGN KEY([ProzedurId])
REFERENCES [dbo].[Prozedur] ([Id])
GO
ALTER TABLE [dbo].[ProzedurParentMapping] CHECK CONSTRAINT [FK_dbo_Prozedur_dbo_Prozedur_ProzedurId]
GO
ALTER TABLE [Navision].[WBKategorie]  WITH CHECK ADD  CONSTRAINT [FK_Navision_WBKategorie_Programm] FOREIGN KEY([NavProgrammId])
REFERENCES [Navision].[WBProgramm] ([NavProgrammId])
GO
ALTER TABLE [Navision].[WBKategorie] CHECK CONSTRAINT [FK_Navision_WBKategorie_Programm]
GO
ALTER TABLE [Navision].[WBProgramm]  WITH CHECK ADD  CONSTRAINT [FK_Navision_WBProgramm_NavDiplomId] FOREIGN KEY([NavDiplomId])
REFERENCES [Navision].[WBTitel] ([NavDiplomId])
GO
ALTER TABLE [Navision].[WBProgramm] CHECK CONSTRAINT [FK_Navision_WBProgramm_NavDiplomId]
GO
ALTER TABLE [Navision].[WBStaette]  WITH CHECK ADD  CONSTRAINT [FK_Navision_WBStaette_Kategorie] FOREIGN KEY([NavKategorieId])
REFERENCES [Navision].[WBKategorie] ([NavKategorieId])
GO
ALTER TABLE [Navision].[WBStaette] CHECK CONSTRAINT [FK_Navision_WBStaette_Kategorie]
GO
ALTER TABLE [Navision].[WBStaette]  WITH CHECK ADD  CONSTRAINT [FK_Navision_WBStaette_Leiter] FOREIGN KEY([LeiterBenutzerId])
REFERENCES [Navision].[Benutzer] ([FMHId])
GO
ALTER TABLE [Navision].[WBStaette] CHECK CONSTRAINT [FK_Navision_WBStaette_Leiter]
GO
ALTER TABLE [Param].[AnforderungsElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_AnforderungsElement_dbo_Taetigkeit] FOREIGN KEY([TaetigkeitId])
REFERENCES [dbo].[TaetigkeitArt] ([Id])
GO
ALTER TABLE [Param].[AnforderungsElement] CHECK CONSTRAINT [FK_Param_AnforderungsElement_dbo_Taetigkeit]
GO
ALTER TABLE [Param].[AnforderungsElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_AnforderungsElement_Param_SegmentVariante] FOREIGN KEY([SegmentVarianteId])
REFERENCES [Param].[SegmentVariante] ([Id])
GO
ALTER TABLE [Param].[AnforderungsElement] CHECK CONSTRAINT [FK_Param_AnforderungsElement_Param_SegmentVariante]
GO
ALTER TABLE [Param].[AnforderungsElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_AnforderungsElement_Param_StrukturElement] FOREIGN KEY([StrukturElementId])
REFERENCES [Param].[StrukturElement] ([Id])
GO
ALTER TABLE [Param].[AnforderungsElement] CHECK CONSTRAINT [FK_Param_AnforderungsElement_Param_StrukturElement]
GO
ALTER TABLE [Param].[AnforderungsElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_AnforderungsElement_Param_StrukturRotation] FOREIGN KEY([StrukturRotationId])
REFERENCES [Param].[StrukturRotation] ([Id])
GO
ALTER TABLE [Param].[AnforderungsElement] CHECK CONSTRAINT [FK_Param_AnforderungsElement_Param_StrukturRotation]
GO
ALTER TABLE [Param].[AnforderungsElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_AnforderungsElement_Param_SummenAnforderung] FOREIGN KEY([SummenAnforderungId])
REFERENCES [Param].[SummenAnforderung] ([Id])
GO
ALTER TABLE [Param].[AnforderungsElement] CHECK CONSTRAINT [FK_Param_AnforderungsElement_Param_SummenAnforderung]
GO
ALTER TABLE [Param].[FachRotation]  WITH CHECK ADD  CONSTRAINT [FK_Param_FachRotation_dbo_LikertSkala] FOREIGN KEY([LikertSkalaId])
REFERENCES [dbo].[LikertSkala] ([Id])
GO
ALTER TABLE [Param].[FachRotation] CHECK CONSTRAINT [FK_Param_FachRotation_dbo_LikertSkala]
GO
ALTER TABLE [Param].[FachRotation]  WITH CHECK ADD  CONSTRAINT [FK_Param_FachRotation_Param_FachRotationThema] FOREIGN KEY([FachRotationThemaId])
REFERENCES [Param].[FachRotationThema] ([Id])
GO
ALTER TABLE [Param].[FachRotation] CHECK CONSTRAINT [FK_Param_FachRotation_Param_FachRotationThema]
GO
ALTER TABLE [Param].[FachRotationOption]  WITH CHECK ADD  CONSTRAINT [FK_Param_FachRotationOption_Param_FachRotation] FOREIGN KEY([FachRotationId])
REFERENCES [Param].[FachRotation] ([Id])
GO
ALTER TABLE [Param].[FachRotationOption] CHECK CONSTRAINT [FK_Param_FachRotationOption_Param_FachRotation]
GO
ALTER TABLE [Param].[FachRotationThema]  WITH CHECK ADD  CONSTRAINT [FK_Param_FachRotationThema_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[FachRotationThema] CHECK CONSTRAINT [FK_Param_FachRotationThema_Param_Revision]
GO
ALTER TABLE [Param].[Gutachten]  WITH CHECK ADD  CONSTRAINT [FK_Param_Gutachten_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[Gutachten] CHECK CONSTRAINT [FK_Param_Gutachten_Param_Revision]
GO
ALTER TABLE [Param].[Hilfsmittel]  WITH CHECK ADD  CONSTRAINT [FK_Param_Hilfsmittel_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[Hilfsmittel] CHECK CONSTRAINT [FK_Param_Hilfsmittel_Param_Revision]
GO
ALTER TABLE [Param].[Hinweis]  WITH CHECK ADD  CONSTRAINT [FK_Param_Hinweis_Param_Hilfsmittel] FOREIGN KEY([HilfsmittelId])
REFERENCES [Param].[Hilfsmittel] ([Id])
GO
ALTER TABLE [Param].[Hinweis] CHECK CONSTRAINT [FK_Param_Hinweis_Param_Hilfsmittel]
GO
ALTER TABLE [Param].[ManuellePruefung]  WITH CHECK ADD  CONSTRAINT [FK_Param_ManuellePruefung_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[ManuellePruefung] CHECK CONSTRAINT [FK_Param_ManuellePruefung_Param_Revision]
GO
ALTER TABLE [Param].[ProzedurEintrag]  WITH CHECK ADD  CONSTRAINT [FK_Param_Prozedur_Param_ProzedurGruppe] FOREIGN KEY([ProzedurGruppeId])
REFERENCES [Param].[ProzedurGruppe] ([Id])
GO
ALTER TABLE [Param].[ProzedurEintrag] CHECK CONSTRAINT [FK_Param_Prozedur_Param_ProzedurGruppe]
GO
ALTER TABLE [Param].[ProzedurGruppe]  WITH CHECK ADD  CONSTRAINT [FK_Param_ProzedurGruppe_Param_ParentId] FOREIGN KEY([ParentId])
REFERENCES [Param].[ProzedurGruppe] ([Id])
GO
ALTER TABLE [Param].[ProzedurGruppe] CHECK CONSTRAINT [FK_Param_ProzedurGruppe_Param_ParentId]
GO
ALTER TABLE [Param].[ProzedurGruppe]  WITH CHECK ADD  CONSTRAINT [FK_Param_ProzedurGruppe_Param_ProzedurTabelle] FOREIGN KEY([ProzedurTabelleId])
REFERENCES [Param].[ProzedurTabelle] ([Id])
GO
ALTER TABLE [Param].[ProzedurGruppe] CHECK CONSTRAINT [FK_Param_ProzedurGruppe_Param_ProzedurTabelle]
GO
ALTER TABLE [Param].[ProzedurMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ProzedurMapping_dbo_Prozedur] FOREIGN KEY([ProzedurId])
REFERENCES [dbo].[Prozedur] ([Id])
GO
ALTER TABLE [Param].[ProzedurMapping] CHECK CONSTRAINT [FK_Param_ProzedurMapping_dbo_Prozedur]
GO
ALTER TABLE [Param].[ProzedurMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ProzedurMapping_Param_ProzedurEintrag] FOREIGN KEY([ProzedurEintragId])
REFERENCES [Param].[ProzedurEintrag] ([Id])
GO
ALTER TABLE [Param].[ProzedurMapping] CHECK CONSTRAINT [FK_Param_ProzedurMapping_Param_ProzedurEintrag]
GO
ALTER TABLE [Param].[ProzedurTabelle]  WITH CHECK ADD  CONSTRAINT [FK_Param_ProzedurTabelle_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[ProzedurTabelle] CHECK CONSTRAINT [FK_Param_ProzedurTabelle_Param_Revision]
GO
ALTER TABLE [Param].[Revision]  WITH CHECK ADD  CONSTRAINT [FK_Param_Revision_Param_Version] FOREIGN KEY([VersionId])
REFERENCES [Param].[Version] ([Id])
GO
ALTER TABLE [Param].[Revision] CHECK CONSTRAINT [FK_Param_Revision_Param_Version]
GO
ALTER TABLE [Param].[Revision]  WITH CHECK ADD  CONSTRAINT [FK_Param_Revision_Param_WBORevision] FOREIGN KEY([WBORevisionId])
REFERENCES [Param].[WBORevision] ([Id])
GO
ALTER TABLE [Param].[Revision] CHECK CONSTRAINT [FK_Param_Revision_Param_WBORevision]
GO
ALTER TABLE [Param].[SammelObjekt]  WITH CHECK ADD  CONSTRAINT [FK_Param_SammelObjekt_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[SammelObjekt] CHECK CONSTRAINT [FK_Param_SammelObjekt_Param_Revision]
GO
ALTER TABLE [Param].[SegmentVariante]  WITH CHECK ADD  CONSTRAINT [FK_Param_SegmentVariante_Param_StrukturSegment] FOREIGN KEY([StrukturSegmentId])
REFERENCES [Param].[StrukturSegment] ([Id])
GO
ALTER TABLE [Param].[SegmentVariante] CHECK CONSTRAINT [FK_Param_SegmentVariante_Param_StrukturSegment]
GO
ALTER TABLE [Param].[Stellung]  WITH CHECK ADD  CONSTRAINT [FK_Param_Stellung_Param_Version] FOREIGN KEY([VersionId])
REFERENCES [Param].[Version] ([Id])
GO
ALTER TABLE [Param].[Stellung] CHECK CONSTRAINT [FK_Param_Stellung_Param_Version]
GO
ALTER TABLE [Param].[StrukturElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_StrukturElement_Param_StrukturElement] FOREIGN KEY([ParentId])
REFERENCES [Param].[StrukturElement] ([Id])
GO
ALTER TABLE [Param].[StrukturElement] CHECK CONSTRAINT [FK_Param_StrukturElement_Param_StrukturElement]
GO
ALTER TABLE [Param].[StrukturElement]  WITH CHECK ADD  CONSTRAINT [FK_Param_StrukturElement_Param_StrukturRotation] FOREIGN KEY([ErfuelltRotationId])
REFERENCES [Param].[StrukturRotation] ([Id])
GO
ALTER TABLE [Param].[StrukturElement] CHECK CONSTRAINT [FK_Param_StrukturElement_Param_StrukturRotation]
GO
ALTER TABLE [Param].[StrukturHauptteil]  WITH CHECK ADD  CONSTRAINT [FK_Param_StrukturHauptteil_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[StrukturHauptteil] CHECK CONSTRAINT [FK_Param_StrukturHauptteil_Param_Revision]
GO
ALTER TABLE [Param].[StrukturRotation]  WITH CHECK ADD  CONSTRAINT [FK_Param_StrukturRotation_Param_Revision] FOREIGN KEY([RevisionId])
REFERENCES [Param].[Revision] ([Id])
GO
ALTER TABLE [Param].[StrukturRotation] CHECK CONSTRAINT [FK_Param_StrukturRotation_Param_Revision]
GO
ALTER TABLE [Param].[StrukturSegment]  WITH CHECK ADD  CONSTRAINT [FK_Param_StrukturSegment_Param_StrukturHauptteil] FOREIGN KEY([StrukturHauptteilId])
REFERENCES [Param].[StrukturHauptteil] ([Id])
GO
ALTER TABLE [Param].[StrukturSegment] CHECK CONSTRAINT [FK_Param_StrukturSegment_Param_StrukturHauptteil]
GO
ALTER TABLE [Param].[SummenAnforderung]  WITH CHECK ADD  CONSTRAINT [FK_Param_SummenAnforderung_dbo_Taetigkeit] FOREIGN KEY([TaetigkeitId])
REFERENCES [dbo].[TaetigkeitArt] ([Id])
GO
ALTER TABLE [Param].[SummenAnforderung] CHECK CONSTRAINT [FK_Param_SummenAnforderung_dbo_Taetigkeit]
GO
ALTER TABLE [Param].[SummenAnforderung]  WITH CHECK ADD  CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturElement] FOREIGN KEY([StrukturElementId])
REFERENCES [Param].[StrukturElement] ([Id])
GO
ALTER TABLE [Param].[SummenAnforderung] CHECK CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturElement]
GO
ALTER TABLE [Param].[SummenAnforderung]  WITH CHECK ADD  CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturHauptteil] FOREIGN KEY([StrukturHauptteilId])
REFERENCES [Param].[StrukturHauptteil] ([Id])
GO
ALTER TABLE [Param].[SummenAnforderung] CHECK CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturHauptteil]
GO
ALTER TABLE [Param].[SummenAnforderung]  WITH CHECK ADD  CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturSegment] FOREIGN KEY([StrukturSegmentId])
REFERENCES [Param].[StrukturSegment] ([Id])
GO
ALTER TABLE [Param].[SummenAnforderung] CHECK CONSTRAINT [FK_Param_SummenAnforderung_Param_StrukturSegment]
GO
ALTER TABLE [Param].[Version]  WITH CHECK ADD  CONSTRAINT [FK_Param_Version_Navision_WBProgramm] FOREIGN KEY([WBProgrammId])
REFERENCES [Navision].[WBProgramm] ([Id])
GO
ALTER TABLE [Param].[Version] CHECK CONSTRAINT [FK_Param_Version_Navision_WBProgramm]
GO
ALTER TABLE [Param].[Version]  WITH CHECK ADD  CONSTRAINT [FK_Param_Version_Navision_WBTitel] FOREIGN KEY([WBTitelId])
REFERENCES [Navision].[WBTitel] ([Id])
GO
ALTER TABLE [Param].[Version] CHECK CONSTRAINT [FK_Param_Version_Navision_WBTitel]
GO
ALTER TABLE [Param].[WBOLernziel]  WITH CHECK ADD  CONSTRAINT [FK_Param_WBOLernziel_Param_WBORevision] FOREIGN KEY([WBORevisionId])
REFERENCES [Param].[WBORevision] ([Id])
GO
ALTER TABLE [Param].[WBOLernziel] CHECK CONSTRAINT [FK_Param_WBOLernziel_Param_WBORevision]
GO
ALTER TABLE [Param].[WBORevision]  WITH CHECK ADD  CONSTRAINT [FK_Param_WBORevision_dbo_LikertSkala] FOREIGN KEY([LikertSkalaId])
REFERENCES [dbo].[LikertSkala] ([Id])
GO
ALTER TABLE [Param].[WBORevision] CHECK CONSTRAINT [FK_Param_WBORevision_dbo_LikertSkala]
GO
ALTER TABLE [Param].[WBORevision]  WITH CHECK ADD  CONSTRAINT [FK_Param_WBORevision_Param_WBOVersion] FOREIGN KEY([WBOVersionId])
REFERENCES [Param].[WBOVersion] ([Id])
GO
ALTER TABLE [Param].[WBORevision] CHECK CONSTRAINT [FK_Param_WBORevision_Param_WBOVersion]
GO
ALTER TABLE [Param].[ZeugnisMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ZeugnisMapping_Param_StrukturElement] FOREIGN KEY([StrukturElementId])
REFERENCES [Param].[StrukturElement] ([Id])
GO
ALTER TABLE [Param].[ZeugnisMapping] CHECK CONSTRAINT [FK_Param_ZeugnisMapping_Param_StrukturElement]
GO
ALTER TABLE [Param].[ZeugnisMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBKategorie] FOREIGN KEY([WBKategorieId])
REFERENCES [Navision].[WBKategorie] ([Id])
GO
ALTER TABLE [Param].[ZeugnisMapping] CHECK CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBKategorie]
GO
ALTER TABLE [Param].[ZeugnisMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBProgramm] FOREIGN KEY([WBProgrammId])
REFERENCES [Navision].[WBProgramm] ([Id])
GO
ALTER TABLE [Param].[ZeugnisMapping] CHECK CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBProgramm]
GO
ALTER TABLE [Param].[ZeugnisMapping]  WITH CHECK ADD  CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBTitel] FOREIGN KEY([WBTitelId])
REFERENCES [Navision].[WBTitel] ([Id])
GO
ALTER TABLE [Param].[ZeugnisMapping] CHECK CONSTRAINT [FK_Param_ZeugnisMapping_Param_WBTitel]
GO
