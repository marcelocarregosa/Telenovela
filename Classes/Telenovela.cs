using System;

namespace Telenovelas
{
  public class Telenovela : BaseEntity
  {
    private Country Country { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }
    private bool Deleted { get; set; }

    public Telenovela(int id, Country country, string title, string description, int year)
    {
      this.Id = id;
      this.Country = country;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.Deleted = false;
    }

    public override string ToString()
    {
      string ret = "";
      ret += "Country: " + this.Country + Environment.NewLine;
      ret += "Title: " + this.Title + Environment.NewLine;
      ret += "Description: " + this.Description + Environment.NewLine;
      ret += "Year: " + this.Year + Environment.NewLine;
      ret += "Deleted: " + this.Deleted + Environment.NewLine;
      return ret;
    }

    public string returnTitle()
    {
      return this.Title;
    }

    public int returnId()
    {
      return this.Id;
    }

    public bool isDeleted()
    {
      return this.Deleted;
    }

    public void Delete()
    {
      this.Deleted = true;
    }
  }
}