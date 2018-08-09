using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Edition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PracaDyplomowaBackend.Data.DbModels.Relations
{
    public class BookEditionTranslator
    {
        [ForeignKey("BookEditionId,BookEditionBookId,BookEditionPublishingHomeId")]       
        public BookEdition BookEdition { get; set; }
        public int BookEditionId { get; set; }
        public int BookEditionBookId { get; set; }
        public int BookEditionPublishingHomeId { get; set; }

        [ForeignKey("TranslatorId")]
        public Translator Translator { get; set; }
        public int TranslatorId { get; set; }
    }
}
