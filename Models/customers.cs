using System;

public class Customers
{
    public long id { get; set; }
    public long user_id { get; set; }
    public long address_id {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}

    public string business_name {get; set;}
    public string contact_full_name {get; set;}
    public string contact_phone {get; set;}
    public string contact_email {get; set;}
    public string business_description {get; set;}

    public string technician_full_name {get; set;}
    public string technician_phone {get; set;}
    public string technician_email {get; set;}
    


}