using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 

namespace Ferret.Models
{
    /// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("recherche")]
    //[System.Xml.Serialization.XmlRootAttribute("recherche", Namespace = "", IsNullable = false)]
    public partial class recherche
    {

        public recherche()
        {

        }

        private string resumeField;

        private string resumeSansTriField;

        private string nbTrouveesField;

        private string nbAffichablesField;

        private string pageCouranteField;

        private string pageMaxField;

        private string pageSuivanteField;

        private string siElargissementBDField;

        private rechercheAnnonce[] annoncesField;

        /// <remarks/>
        public string resume
        {
            get
            {
                return this.resumeField;
            }
            set
            {
                this.resumeField = value;
            }
        }

        /// <remarks/>
        public string resumeSansTri
        {
            get
            {
                return this.resumeSansTriField;
            }
            set
            {
                this.resumeSansTriField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbTrouvees
        {
            get
            {
                return this.nbTrouveesField;
            }
            set
            {
                this.nbTrouveesField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbAffichables
        {
            get
            {
                return this.nbAffichablesField;
            }
            set
            {
                this.nbAffichablesField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string pageCourante
        {
            get
            {
                return this.pageCouranteField;
            }
            set
            {
                this.pageCouranteField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string pageMax
        {
            get
            {
                return this.pageMaxField;
            }
            set
            {
                this.pageMaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI", IsNullable = true)]
        public string pageSuivante
        {
            get
            {
                return this.pageSuivanteField;
            }
            set
            {
                this.pageSuivanteField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string siElargissementBD
        {
            get
            {
                return this.siElargissementBDField;
            }
            set
            {
                this.siElargissementBDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArray("annonces", IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("annonce", IsNullable = true)]
        public rechercheAnnonce[] annonces
        {
            get
            {
                return this.annoncesField;
            }
            set
            {
                this.annoncesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rechercheAnnonce
    {

        private string idTiersField;

        private int idAnnonceField;

        private int? idAgenceField;

        private int? idPublicationField;

        private int? idTypeTransactionField;

        private int? idTypeBienField;

        private int? idSousTypeBienField;

        private bool idSousTypeBienFieldSpecified;

        private System.DateTime dtFraicheurField;

        private System.DateTime dtCreationField;

        private string titreField;

        private string libelleField;

        private string proximiteField;

        private string descriptifField;

        private double? prixField;

        private string prixUniteField;

        private string prixMentionField;

        private double? loyerAnnuelM2Field;

        private bool loyerAnnuelM2FieldSpecified;

        private string loyerAnnuelM2UniteField;

        private double? loyerAnnuelField;

        private bool loyerAnnuelFieldSpecified;

        private string loyerAnnuelUniteField;

        private string nbPieceField;

        private string nbChambreField;

        private bool nbChambreFieldSpecified;

        private double? surfaceField;

        private bool surfaceFieldSpecified;

        private string surfaceUniteField;

        private int? idPaysField;

        private string paysField;

        private int? cpField;

        private int? codeInseeField;

        private string villeField;

        private string logoTnyUrlField;

        private string logoBigUrlField;

        private string nbPhotosField;

        private string firstThumbField;

        private string permaLienField;

        private double? latitudeField;

        private double? longitudeField;

        private string llPrecisionField;

        private string typeDPEField;

        private string consoEnergieField;

        private bool consoEnergieFieldSpecified;

        private string bilanConsoEnergieField;

        private string emissionGESField;

        private bool emissionGESFieldSpecified;

        private string bilanEmissionGESField;

        private string siLotNeufField;

        private string siMandatExclusifField;

        private string siMandatStarField;

        private rechercheAnnonceContact contactField;

        private rechercheAnnoncePhotos photosField;

        private string nbsallesdebainField;

        private string nbsalleseauField;

        private string nbtoilettesField;

        private string sisejourField;

        private string surfsejourField;

        private string anneeconstructField;

        private string nbparkingsField;

        private string nbboxesField;

        private string siterrasseField;

        private string nbterrassesField;

        private string sipiscineField;

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string idTiers
        {
            get
            {
                return this.idTiersField;
            }
            set
            {
                this.idTiersField = value;
            }
        }

        /// <remarks/>
        public int idAnnonce
        {
            get
            {
                return this.idAnnonceField;
            }
            set
            {
                this.idAnnonceField = value;
            }
        }

        /// <remarks/>
        public int? idAgence
        {
            get
            {
                return this.idAgenceField;
            }
            set
            {
                this.idAgenceField = value;
            }
        }

        /// <remarks/>
        public int? idPublication
        {
            get
            {
                return this.idPublicationField;
            }
            set
            {
                this.idPublicationField = value;
            }
        }

        /// <remarks/>
        public int? idTypeTransaction
        {
            get
            {
                return this.idTypeTransactionField;
            }
            set
            {
                this.idTypeTransactionField = value;
            }
        }

        /// <remarks/>
        public int? idTypeBien
        {
            get
            {
                return this.idTypeBienField;
            }
            set
            {
                this.idTypeBienField = value;
            }
        }

        /// <remarks/>
        public int? idSousTypeBien
        {
            get
            {
                return this.idSousTypeBienField;
            }
            set
            {
                this.idSousTypeBienField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSousTypeBienSpecified
        {
            get
            {
                return this.idSousTypeBienFieldSpecified;
            }
            set
            {
                this.idSousTypeBienFieldSpecified = value;
            }
        }

        /// <remarks/>
        public System.DateTime dtFraicheur
        {
            get
            {
                return this.dtFraicheurField;
            }
            set
            {
                this.dtFraicheurField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dtCreation
        {
            get
            {
                return this.dtCreationField;
            }
            set
            {
                this.dtCreationField = value;
            }
        }

        /// <remarks/>
        public string titre
        {
            get
            {
                return this.titreField;
            }
            set
            {
                this.titreField = value;
            }
        }

        /// <remarks/>
        public string libelle
        {
            get
            {
                return this.libelleField;
            }
            set
            {
                this.libelleField = value;
            }
        }

        /// <remarks/>
        public string proximite
        {
            get
            {
                return this.proximiteField;
            }
            set
            {
                this.proximiteField = value;
            }
        }

        /// <remarks/>
        public string descriptif
        {
            get
            {
                return this.descriptifField;
            }
            set
            {
                this.descriptifField = value;
            }
        }

        /// <remarks/>
        public double? prix
        {
            get
            {
                return this.prixField;
            }
            set
            {
                this.prixField = value;
            }
        }

        /// <remarks/>
        public string prixUnite
        {
            get
            {
                return this.prixUniteField;
            }
            set
            {
                this.prixUniteField = value;
            }
        }

        /// <remarks/>
        public string prixMention
        {
            get
            {
                return this.prixMentionField;
            }
            set
            {
                this.prixMentionField = value;
            }
        }

        /// <remarks/>
        public double? loyerAnnuelM2
        {
            get
            {
                return this.loyerAnnuelM2Field;
            }
            set
            {
                this.loyerAnnuelM2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool loyerAnnuelM2Specified
        {
            get
            {
                return this.loyerAnnuelM2FieldSpecified;
            }
            set
            {
                this.loyerAnnuelM2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public string loyerAnnuelM2Unite
        {
            get
            {
                return this.loyerAnnuelM2UniteField;
            }
            set
            {
                this.loyerAnnuelM2UniteField = value;
            }
        }

        /// <remarks/>
        public double? loyerAnnuel
        {
            get
            {
                return this.loyerAnnuelField;
            }
            set
            {
                this.loyerAnnuelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool loyerAnnuelSpecified
        {
            get
            {
                return this.loyerAnnuelFieldSpecified;
            }
            set
            {
                this.loyerAnnuelFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string loyerAnnuelUnite
        {
            get
            {
                return this.loyerAnnuelUniteField;
            }
            set
            {
                this.loyerAnnuelUniteField = value;
            }
        }

        /// <remarks/>
        public string nbPiece
        {
            get
            {
                return this.nbPieceField;
            }
            set
            {
                this.nbPieceField = value;
            }
        }

        /// <remarks/>
        public string nbChambre
        {
            get
            {
                return this.nbChambreField;
            }
            set
            {
                this.nbChambreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nbChambreSpecified
        {
            get
            {
                return this.nbChambreFieldSpecified;
            }
            set
            {
                this.nbChambreFieldSpecified = value;
            }
        }

        /// <remarks/>
        public double? surface
        {
            get
            {
                return this.surfaceField;
            }
            set
            {
                this.surfaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool surfaceSpecified
        {
            get
            {
                return this.surfaceFieldSpecified;
            }
            set
            {
                this.surfaceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string surfaceUnite
        {
            get
            {
                return this.surfaceUniteField;
            }
            set
            {
                this.surfaceUniteField = value;
            }
        }

        /// <remarks/>
        public int? idPays
        {
            get
            {
                return this.idPaysField;
            }
            set
            {
                this.idPaysField = value;
            }
        }

        /// <remarks/>
        public string pays
        {
            get
            {
                return this.paysField;
            }
            set
            {
                this.paysField = value;
            }
        }

        /// <remarks/>
        public int? cp
        {
            get
            {
                return this.cpField;
            }
            set
            {
                this.cpField = value;
            }
        }

        /// <remarks/>
        public int? codeInsee
        {
            get
            {
                return this.codeInseeField;
            }
            set
            {
                this.codeInseeField = value;
            }
        }

        /// <remarks/>
        public string ville
        {
            get
            {
                return this.villeField;
            }
            set
            {
                this.villeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string logoTnyUrl
        {
            get
            {
                return this.logoTnyUrlField;
            }
            set
            {
                this.logoTnyUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string logoBigUrl
        {
            get
            {
                return this.logoBigUrlField;
            }
            set
            {
                this.logoBigUrlField = value;
            }
        }

        /// <remarks/>
        public string nbPhotos
        {
            get
            {
                return this.nbPhotosField;
            }
            set
            {
                this.nbPhotosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string firstThumb
        {
            get
            {
                return this.firstThumbField;
            }
            set
            {
                this.firstThumbField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string permaLien
        {
            get
            {
                return this.permaLienField;
            }
            set
            {
                this.permaLienField = value;
            }
        }

        /// <remarks/>
        public double? latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public double? longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        public string llPrecision
        {
            get
            {
                return this.llPrecisionField;
            }
            set
            {
                this.llPrecisionField = value;
            }
        }

        /// <remarks/>
        public string typeDPE
        {
            get
            {
                return this.typeDPEField;
            }
            set
            {
                this.typeDPEField = value;
            }
        }

        /// <remarks/>
        public string consoEnergie
        {
            get
            {
                return this.consoEnergieField;
            }
            set
            {
                this.consoEnergieField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool consoEnergieSpecified
        {
            get
            {
                return this.consoEnergieFieldSpecified;
            }
            set
            {
                this.consoEnergieFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string bilanConsoEnergie
        {
            get
            {
                return this.bilanConsoEnergieField;
            }
            set
            {
                this.bilanConsoEnergieField = value;
            }
        }

        /// <remarks/>
        public string emissionGES
        {
            get
            {
                return this.emissionGESField;
            }
            set
            {
                this.emissionGESField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool emissionGESSpecified
        {
            get
            {
                return this.emissionGESFieldSpecified;
            }
            set
            {
                this.emissionGESFieldSpecified = value;
            }
        }

        /// <remarks/>
        
        public string bilanEmissionGES
        {
            get
            {
                return this.bilanEmissionGESField;
            }
            set
            {
                this.bilanEmissionGESField = value;
            }
        }

        /// <remarks/>
        public string siLotNeuf
        {
            get
            {
                return this.siLotNeufField;
            }
            set
            {
                this.siLotNeufField = value;
            }
        }

        /// <remarks/>
        public string siMandatExclusif
        {
            get
            {
                return this.siMandatExclusifField;
            }
            set
            {
                this.siMandatExclusifField = value;
            }
        }

        /// <remarks/>
        public string siMandatStar
        {
            get
            {
                return this.siMandatStarField;
            }
            set
            {
                this.siMandatStarField = value;
            }
        }

        /// <remarks/>
        public rechercheAnnonceContact contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        public rechercheAnnoncePhotos photos
        {
            get
            {
                return this.photosField;
            }
            set
            {
                this.photosField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbsallesdebain
        {
            get
            {
                return this.nbsallesdebainField;
            }
            set
            {
                this.nbsallesdebainField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbsalleseau
        {
            get
            {
                return this.nbsalleseauField;
            }
            set
            {
                this.nbsalleseauField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbtoilettes
        {
            get
            {
                return this.nbtoilettesField;
            }
            set
            {
                this.nbtoilettesField = value;
            }
        }

        /// <remarks/>
        public string sisejour
        {
            get
            {
                return this.sisejourField;
            }
            set
            {
                this.sisejourField = value;
            }
        }

        /// <remarks/>
        public string surfsejour
        {
            get
            {
                return this.surfsejourField;
            }
            set
            {
                this.surfsejourField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string anneeconstruct
        {
            get
            {
                return this.anneeconstructField;
            }
            set
            {
                this.anneeconstructField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbparkings
        {
            get
            {
                return this.nbparkingsField;
            }
            set
            {
                this.nbparkingsField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbboxes
        {
            get
            {
                return this.nbboxesField;
            }
            set
            {
                this.nbboxesField = value;
            }
        }

        /// <remarks/>
        public string siterrasse
        {
            get
            {
                return this.siterrasseField;
            }
            set
            {
                this.siterrasseField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string nbterrasses
        {
            get
            {
                return this.nbterrassesField;
            }
            set
            {
                this.nbterrassesField = value;
            }
        }

        /// <remarks/>
        [XmlElement(IsNullable = true)]
        public string sipiscine
        {
            get
            {
                return this.sipiscineField;
            }
            set
            {
                this.sipiscineField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rechercheAnnonceContact
    {

        private string siAudiotelField;

        private int? idPublicationField;

        private string nomField;

        private string rcsSirenField;

        private bool rcsSirenFieldSpecified;

        private string rcsNicField;

        private bool rcsNicFieldSpecified;

        /// <remarks/>
        public string siAudiotel
        {
            get
            {
                return this.siAudiotelField;
            }
            set
            {
                this.siAudiotelField = value;
            }
        }

        /// <remarks/>
        public int? idPublication
        {
            get
            {
                return this.idPublicationField;
            }
            set
            {
                this.idPublicationField = value;
            }
        }

        /// <remarks/>
        public string nom
        {
            get
            {
                return this.nomField;
            }
            set
            {
                this.nomField = value;
            }
        }

        /// <remarks/>
        public string rcsSiren
        {
            get
            {
                return this.rcsSirenField;
            }
            set
            {
                this.rcsSirenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rcsSirenSpecified
        {
            get
            {
                return this.rcsSirenFieldSpecified;
            }
            set
            {
                this.rcsSirenFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string rcsNic
        {
            get
            {
                return this.rcsNicField;
            }
            set
            {
                this.rcsNicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rcsNicSpecified
        {
            get
            {
                return this.rcsNicFieldSpecified;
            }
            set
            {
                this.rcsNicFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rechercheAnnoncePhotos
    {

        private rechercheAnnoncePhotosPhoto[] photoField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("photo")]
        public rechercheAnnoncePhotosPhoto[] photo
        {
            get
            {
                return this.photoField;
            }
            set
            {
                this.photoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rechercheAnnoncePhotosPhoto
    {

        private string titreField;

        private sbyte ordreField;

        private string thbUrlField;

        private string carreurlField;

        private string bigUrlField;

        private string stdUrlField;

        private string c175urlField;

        private string stdwidthField;

        private string stdheightField;

        private string thumbwidthField;

        private string thumbheightField;

        private string bigwidthField;

        private string bigheightField;

        /// <remarks/>
        public string titre
        {
            get
            {
                return this.titreField;
            }
            set
            {
                this.titreField = value;
            }
        }

        /// <remarks/>
        public sbyte ordre
        {
            get
            {
                return this.ordreField;
            }
            set
            {
                this.ordreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string thbUrl
        {
            get
            {
                return this.thbUrlField;
            }
            set
            {
                this.thbUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string carreurl
        {
            get
            {
                return this.carreurlField;
            }
            set
            {
                this.carreurlField = value;
            }
        }

        /// <remarks/>
        public string bigUrl
        {
            get
            {
                return this.bigUrlField;
            }
            set
            {
                this.bigUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string stdUrl
        {
            get
            {
                return this.stdUrlField;
            }
            set
            {
                this.stdUrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI")]
        public string c175url
        {
            get
            {
                return this.c175urlField;
            }
            set
            {
                this.c175urlField = value;
            }
        }

        /// <remarks/>
        public string stdwidth
        {
            get
            {
                return this.stdwidthField;
            }
            set
            {
                this.stdwidthField = value;
            }
        }

        /// <remarks/>
        public string stdheight
        {
            get
            {
                return this.stdheightField;
            }
            set
            {
                this.stdheightField = value;
            }
        }

        /// <remarks/>
        public string thumbwidth
        {
            get
            {
                return this.thumbwidthField;
            }
            set
            {
                this.thumbwidthField = value;
            }
        }

        /// <remarks/>
        public string thumbheight
        {
            get
            {
                return this.thumbheightField;
            }
            set
            {
                this.thumbheightField = value;
            }
        }

        /// <remarks/>
        public string bigwidth
        {
            get
            {
                return this.bigwidthField;
            }
            set
            {
                this.bigwidthField = value;
            }
        }

        /// <remarks/>
        public string bigheight
        {
            get
            {
                return this.bigheightField;
            }
            set
            {
                this.bigheightField = value;
            }
        }
    }
}
