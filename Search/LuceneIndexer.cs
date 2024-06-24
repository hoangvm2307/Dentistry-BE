using DentistryBusinessObjects;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Search
{
  public class LuceneIndexer
  {
    private readonly Lucene.Net.Store.Directory _indexDirectory;
    private readonly Analyzer _analyzer;
    private readonly IndexWriterConfig _indexWriterConfig;
    private readonly IndexWriter _writer;

    public LuceneIndexer(string indexPath)
    {
      _indexDirectory = FSDirectory.Open(new DirectoryInfo(indexPath));
      _analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
      _indexWriterConfig = new IndexWriterConfig(LuceneVersion.LUCENE_48, _analyzer);
      _writer = new IndexWriter(_indexDirectory, _indexWriterConfig);
    }

    public void IndexClinic(Clinic clinic)
    {
      var doc = new Document
        {
           new StringField("ClinicId", clinic.ClinicID.ToString(), Field.Store.YES),
            new TextField("Name", clinic.Name, Field.Store.YES),
            new TextField("Address", clinic.Address, Field.Store.YES),
            new StringField("PhoneNumber", clinic.PhoneNumber, Field.Store.YES),
            new StringField("Email", clinic.Email, Field.Store.YES),
            new StringField("OpeningHours", clinic.OpeningHours.ToString(), Field.Store.YES),
            new StringField("ClosingHours", clinic.ClosingHours.ToString(), Field.Store.YES),
            new StringField("Status", clinic.Status.ToString(), Field.Store.YES),
            new StringField("Type", "Clinic", Field.Store.YES)
        };
       
      _writer.AddDocument(doc);
    }

    public void IndexDentist(Dentist dentist)
    {
      var doc = new Document
    {
        new StringField("DentistId", dentist.DentistID.ToString(), Field.Store.YES),
        new TextField("Name", dentist.Name, Field.Store.YES),
        new StringField("DentistPhoneNumber", dentist.PhoneNumber, Field.Store.YES),
        new StringField("Email", dentist.Email, Field.Store.YES),
        new StringField("Specialization", dentist.Specialization, Field.Store.YES),
        new StringField("Status", dentist.Status.ToString(), Field.Store.YES),
        new StringField("ClinicId", dentist.ClinicID.ToString(), Field.Store.YES),
        new StringField("Type", "Dentist", Field.Store.YES)
    };

      // Index Appointments (if needed)
      if (dentist.Appointments != null)
      {
        foreach (var appointment in dentist.Appointments)
        {
          doc.Add(new StringField("AppointmentId", appointment.AppointmentID.ToString(), Field.Store.YES));
          doc.Add(new StringField("AppointmentDate", appointment.AppointmentDate.ToString("yyyy-MM-dd"), Field.Store.YES));
        }
      }

      // Index TreatmentPlans (if needed)
      if (dentist.TreatmentPlans != null)
      {
        foreach (var plan in dentist.TreatmentPlans)
        {
          doc.Add(new StringField("TreatmentPlanId", plan.PlanID.ToString(), Field.Store.YES));
        }
      }

      // Index ChatMessages (if needed)
      if (dentist.ChatMessages != null)
      {
        foreach (var message in dentist.ChatMessages)
        {
          doc.Add(new TextField("ChatMessage", message.MessageContent, Field.Store.YES));
        }
      }

      _writer.AddDocument(doc);
    }


    public void IndexService(Service service)
    {
      var doc = new Document
    {
        new StringField("Id", service.ServiceID.ToString(), Field.Store.YES),
        new TextField("Name", service.Name, Field.Store.YES),
        new TextField("Description", service.Description ?? "", Field.Store.YES),
        new Int32Field("Duration", service.Duration, Field.Store.YES),
        new StringField("Price", service.Price.ToString(), Field.Store.YES),
        new StringField("ClinicId", service.ClinicID.ToString(), Field.Store.YES),
        new StringField("Type", "Service", Field.Store.YES)
    };

      // Index Appointments (if needed)
      if (service.Appointments != null)
      {
        foreach (var appointment in service.Appointments)
        {
          doc.Add(new StringField("AppointmentId", appointment.AppointmentID.ToString(), Field.Store.YES));
          doc.Add(new StringField("AppointmentDate", appointment.AppointmentDate.ToString("yyyy-MM-dd"), Field.Store.YES));
        }
      }

      _writer.AddDocument(doc);
    }

    public void Commit()
    {
      _writer.Commit();
    }

    public void Dispose()
    {
      _writer?.Dispose();
      _analyzer?.Dispose();
      _indexDirectory?.Dispose();
    }
  }
}
