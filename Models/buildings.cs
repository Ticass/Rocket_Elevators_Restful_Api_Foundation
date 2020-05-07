using System;



public class Buildings
{
    public long id { get; set; }
    public long customer_id { get; set; }
    public long address_id { get; set; }
    public string building_administrator_full_name {get; set;}
    public string building_administrator_email {get; set;}
    public string building_administrator_phone {get; set;}
    public string building_technical_contact_name {get; set;}
    public string building_technical_contact_email {get; set;}
    public string building_technical_contact_phone {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}

}