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
        public Guid BookEditionId { get; set; }
        public Guid BookEditionBookId { get; set; }
        public Guid BookEditionPublishingHomeId { get; set; }

        [ForeignKey("TranslatorId")]
        public Translator Translator { get; set; }
        public Guid TranslatorId { get; set; }
    }
}
