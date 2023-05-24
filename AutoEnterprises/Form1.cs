using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoEnterprises.Form1;

namespace AutoEnterprises
{
    public partial class Form1 : Form
    {
        public string Mode = "";
        public string Feature = "вместимость";
        public string FeatureAdd = "число_пассажиров";

        public static IMongoClient client = new MongoClient();

        public static IMongoDatabase db = client.GetDatabase("AutoEnterprises");

        public static IMongoCollection<Staff> StaffCollection = db.GetCollection<Staff>("Staff");
        public static IMongoCollection<Transport> TransportCollection = db.GetCollection<Transport>("Transport");
        public static IMongoCollection<Brigades> BrigadesCollection = db.GetCollection<Brigades>("Brigades");
        public static IMongoCollection<Drivers> DriversCollection = db.GetCollection<Drivers>("Drivers");
        public static IMongoCollection<Facilities> FacilitiesCollection = db.GetCollection<Facilities>("Facilities");
        public static IMongoCollection<Repairs> RepairsCollection = db.GetCollection<Repairs>("Repairs");
        public static IMongoCollection<Routes> RoutesCollection = db.GetCollection<Routes>("Routes");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ReadDataStaff()
        {
            List<Staff> staffs = StaffCollection.AsQueryable().ToList();
            dataGridView1.DataSource = staffs;
        }

        public void ReadDataDrivers()
        {
            List<Drivers> drivers = DriversCollection.AsQueryable().ToList();
            dataGridView1.DataSource = drivers;
        }

        public void ReadDataFacilities()
        {
            List<Facilities> facilities = FacilitiesCollection.AsQueryable().ToList();
            dataGridView1.DataSource = facilities;
        }

        public void ReadDataTransport()
        {
            List<Transport> transports = TransportCollection.AsQueryable().ToList();
            dataGridView1.DataSource = transports;
        }

        public void ReadDataBrigades()
        {
            List<Brigades> brigades = BrigadesCollection.AsQueryable().ToList();
            dataGridView1.DataSource = brigades;
        }

        public void ReadDataRepairs()
        {
            List<Repairs> repairs = RepairsCollection.AsQueryable().ToList();
            dataGridView1.DataSource = repairs;
        }

        public void ReadDataRoutes()
        {
            List<Routes> routes = RoutesCollection.AsQueryable().ToList();
            dataGridView1.DataSource = routes;
        }

        private void ColumnsVisible()
        {
            for (int i = 0; i < insertTable.ColumnCount; i++)
            {
                insertTable.Columns[i].Visible = true;
            }
        }

        public class Drivers
        {
            public Drivers(string id, string lastName, string firstName, string middleName, BsonDocument transport)
            {
                Id = id;
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
                Transport = transport;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("фамилия")] public string LastName { get; set; }
            [BsonElement("имя")] public string FirstName { get; set; }
            [BsonElement("отчество")] public string MiddleName { get; set; }
            [BsonElement("транспорт")] public BsonDocument Transport { get; set; }
        }

        public class Routes
        {
            public Routes(string id, BsonArray dates, string name, string transportType, BsonArray transport)
            {
                Id = id;
                Dates = dates;
                Name = name;
                TransportType = transportType;
                Transport = transport;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("даты")] public BsonArray Dates { get; set; }
            [BsonElement("название")] public string Name { get; set; }
            [BsonElement("тип_транспорта")] public string TransportType { get; set; }
            [BsonElement("транспорт")] public BsonArray Transport { get; set; }
        }

        public class Repairs
        {
            public Repairs(string id, BsonDateTime date, string repairItem, int cost, string type, BsonArray members)
            {
                Id = id;
                Date = date;
                RepairItem = repairItem;
                Cost = cost;
                Type = type;
                Members = members;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("дата")] public BsonDateTime Date { get; set; }
            [BsonElement("предмет_ремонта")] public string RepairItem { get; set; }
            [BsonElement("стоимость")] public int Cost { get; set; }
            [BsonElement("тип")] public string Type { get; set; }
            [BsonElement("участники")] public BsonArray Members { get; set; }
        }

        public class Facilities
        {
            public Facilities(string id, string name, string type, BsonArray transport)
            {
                Id = id;
                Name = name;
                Type = type;
                Transport = transport;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("название")] public string Name { get; set; }
            [BsonElement("тип")] public string Type { get; set; }
            [BsonElement("транспорт")] public BsonArray Transport { get; set; }
        }

        public class Brigades
        {
            public Brigades(string id, BsonDocument brigadier, BsonArray drivers, BsonDocument foreman, string name, BsonDocument supervisor, BsonArray workers)
            {
                Id = id;
                Brigadier = brigadier;
                Drivers = drivers;
                Foreman = foreman;
                Name = name;
                Supervisor = supervisor;
                Workers = workers;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("бригадир")] public BsonDocument Brigadier { get; set; }
            [BsonElement("водители")] public BsonArray Drivers { get; set; }
            [BsonElement("мастер")] public BsonDocument Foreman { get; set; }
            [BsonElement("название")] public string Name { get; set; }
            [BsonElement("начальник")] public BsonDocument Supervisor { get; set; }
            [BsonElement("рабочие")] public BsonArray Workers { get; set; }
        }

        public class Transport
        {
            public Transport(string id, int issueYear, string brand, int mileage, string type, BsonArray repair, BsonDocument сharacteristics, BsonDocument driver)
            {
                Id = id;
                IssueYear = issueYear;
                Brand = brand;
                Mileage = mileage;
                Type = type;
                Repair = repair;
                Сharacteristics = сharacteristics;
                Driver = driver;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("год_выпуска")] public int IssueYear { get; set; }
            [BsonElement("марка")] public string Brand { get; set; }
            [BsonElement("пробег")] public int Mileage { get; set; }
            [BsonElement("тип")] public string Type { get; set; }
            [BsonElement("ремонт")] public BsonArray Repair { get; set; }
            [BsonElement("характеристики")] public BsonDocument Сharacteristics { get; set; }
            [BsonElement("водитель")] public BsonDocument Driver { get; set; }
        }

        public class Staff
        {
            public Staff(string id, string lastName, string firstName, string middleName, string position, string specialisation)
            {
                Id = id;
                LastName = lastName;
                FirstName = firstName;
                MiddleName = middleName;
                Position = position;
                Specialisation = specialisation;
            }

            [BsonId] public string Id { get; set; }
            [BsonElement("фамилия")] public string LastName { get; set; }
            [BsonElement("имя")] public string FirstName { get; set; }
            [BsonElement("отчество")] public string MiddleName { get; set; }
            [BsonElement("должность")] public string Position { get; set; }
            [BsonElement("специализация")] public string Specialisation { get; set; }
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataStaff();
            Mode = "Staff";
            changeButton.Visible = false;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "фамилия";
            insertTable.Columns[2].HeaderText = "имя";
            insertTable.Columns[3].HeaderText = "отчество";
            insertTable.Columns[4].HeaderText = "должность";
            insertTable.Columns[5].HeaderText = "специализация";
            insertTable.Columns[6].Visible = false;
            insertTable.Columns[7].Visible = false;
            insertTable.Columns[8].Visible = false;
            insertTable.Columns[9].Visible = false;
            insertTable.Columns[10].Visible = false;
            insertTable.Columns[11].Visible = false;
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataTransport();
            Mode = "Transport";
            changeButton.Visible = true;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "год выпуска";
            insertTable.Columns[2].HeaderText = "марка";
            insertTable.Columns[3].HeaderText = "пробег";
            insertTable.Columns[4].HeaderText = "тип";
            insertTable.Columns[5].HeaderText = "тип ремонта";
            insertTable.Columns[6].HeaderText = "стоимость ремонта";
            insertTable.Columns[7].HeaderText = "_id ремонта";
            insertTable.Columns[8].HeaderText = "вместимость";
            insertTable.Columns[9].HeaderText = "дата";
            insertTable.Columns[10].HeaderText = "статус";
            insertTable.Columns[11].HeaderText = "фамилия водителя";
            insertTable.Columns[12].HeaderText = "_id водителя";
            insertTable.Columns[13].Visible = false;
        }

        private void brigadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataBrigades();
            Mode = "Brigades";
            changeButton.Visible = false;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "фамилия бригадира";
            insertTable.Columns[2].HeaderText = "_id бригадира";
            insertTable.Columns[3].HeaderText = "фамилия водителя";
            insertTable.Columns[4].HeaderText = "_id водителя";
            insertTable.Columns[5].HeaderText = "фамилия мастера";
            insertTable.Columns[6].HeaderText = "_id мастера";
            insertTable.Columns[7].HeaderText = "название";
            insertTable.Columns[8].HeaderText = "фамилия начальника";
            insertTable.Columns[9].HeaderText = "_id начальника";
            insertTable.Columns[10].HeaderText = "фамилия рабочего";
            insertTable.Columns[11].HeaderText = "_id рабочего";
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void facilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataFacilities();
            Mode = "Facilities";
            changeButton.Visible = false;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "название";
            insertTable.Columns[2].HeaderText = "тип";
            insertTable.Columns[3].HeaderText = "тип транспорта";
            insertTable.Columns[4].HeaderText = "_id транспорта";
            insertTable.Columns[5].Visible = false;
            insertTable.Columns[6].Visible = false;
            insertTable.Columns[7].Visible = false;
            insertTable.Columns[8].Visible = false;
            insertTable.Columns[9].Visible = false;
            insertTable.Columns[10].Visible = false;
            insertTable.Columns[11].Visible = false;
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void repairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataRepairs();
            Mode = "Repairs";
            changeButton.Visible = false;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "дата";
            insertTable.Columns[2].HeaderText = "предмет ремонта";
            insertTable.Columns[3].HeaderText = "стоимость";
            insertTable.Columns[4].HeaderText = "тип";
            insertTable.Columns[5].HeaderText = "фамилия участника";
            insertTable.Columns[6].HeaderText = "_id участника";
            insertTable.Columns[7].Visible = false;
            insertTable.Columns[8].Visible = false;
            insertTable.Columns[9].Visible = false;
            insertTable.Columns[10].Visible = false;
            insertTable.Columns[11].Visible = false;
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataDrivers();
            Mode = "Drivers";
            changeButton.Visible = false;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "фамилия";
            insertTable.Columns[2].HeaderText = "имя";
            insertTable.Columns[3].HeaderText = "отчество";
            insertTable.Columns[4].HeaderText = "_id транспорта";
            insertTable.Columns[5].HeaderText = "тип транспорта";
            insertTable.Columns[6].Visible = false;
            insertTable.Columns[7].Visible = false;
            insertTable.Columns[8].Visible = false;
            insertTable.Columns[9].Visible = false;
            insertTable.Columns[10].Visible = false;
            insertTable.Columns[11].Visible = false;
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void routesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable.Rows.Clear();
            ReadDataRoutes();
            Mode = "Routes";
            changeButton.Visible = true;
            ColumnsVisible();
            insertTable.Columns[0].HeaderText = "_id";
            insertTable.Columns[1].HeaderText = "дата";
            insertTable.Columns[2].HeaderText = "объем грузоперевозки"; //число_пассажиров
            insertTable.Columns[3].HeaderText = "название";
            insertTable.Columns[4].HeaderText = "тип транспорта";
            insertTable.Columns[5].HeaderText = "грузоподъемность транспорта";
            insertTable.Columns[6].HeaderText = "_id транспорта";
            insertTable.Columns[7].Visible = false;
            insertTable.Columns[8].Visible = false;
            insertTable.Columns[9].Visible = false;
            insertTable.Columns[10].Visible = false;
            insertTable.Columns[11].Visible = false;
            insertTable.Columns[12].Visible = false;
            insertTable.Columns[13].Visible = false;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (Mode == "Staff")
            {
                Staff staff = new Staff(insertTable.Rows[0].Cells[0].Value.ToString(), insertTable.Rows[0].Cells[1].Value.ToString(), insertTable.Rows[0].Cells[2].Value.ToString(), insertTable.Rows[0].Cells[3].Value.ToString(), insertTable.Rows[0].Cells[4].Value.ToString(), insertTable.Rows[0].Cells[5].Value.ToString());
                StaffCollection.InsertOne(staff);
                ReadDataStaff();
            }
            else if (Mode == "Drivers")
            {
                BsonDocument transport = new BsonDocument { { "_id", insertTable.Rows[0].Cells[4].Value.ToString() }, { "тип", insertTable.Rows[0].Cells[5].Value.ToString() } };
                Drivers drivers = new Drivers(insertTable.Rows[0].Cells[0].Value.ToString(), insertTable.Rows[0].Cells[1].Value.ToString(), insertTable.Rows[0].Cells[2].Value.ToString(), insertTable.Rows[0].Cells[3].Value.ToString(), transport);
                DriversCollection.InsertOne(drivers);
                ReadDataDrivers();
            }
            else if (Mode == "Facilities")
            {
                BsonArray transports = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[3].Value != null && insertTable.Rows[i].Cells[4].Value != null)
                    {
                        transports.Add(new BsonDocument { { "тип", insertTable.Rows[i].Cells[3].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[4].Value.ToString() } });
                    }
                }

                Facilities facilities = new Facilities(insertTable.Rows[0].Cells[0].Value.ToString(), insertTable.Rows[0].Cells[1].Value.ToString(), insertTable.Rows[0].Cells[2].Value.ToString(), transports);
                FacilitiesCollection.InsertOne(facilities);
                ReadDataFacilities();
            }
            else if (Mode == "Transport")
            {
                BsonDocument characteristics = new BsonDocument { { Feature, insertTable.Rows[0].Cells[8].Value.ToString() }, { "статус", insertTable.Rows[0].Cells[10].Value.ToString() }, { "дата", Convert.ToDateTime(insertTable.Rows[0].Cells[9].Value) } };
                BsonDocument driver = new BsonDocument { { "фамилия", insertTable.Rows[0].Cells[11].Value.ToString() }, { "_id", insertTable.Rows[0].Cells[12].Value.ToString() } };
                BsonArray repairs = new BsonArray();
                for (int i = 0; i < insertTable.RowCount-1; i++)
                {
                    if (insertTable.Rows[i].Cells[5].Value != null && insertTable.Rows[i].Cells[6].Value != null && insertTable.Rows[i].Cells[7].Value != null)
                    {
                        repairs.Add(new BsonDocument { { "тип", insertTable.Rows[i].Cells[5].Value.ToString() }, { "стоимость", insertTable.Rows[i].Cells[6].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[7].Value.ToString() } });
                    }
                }
                Transport transports = new Transport(insertTable.Rows[0].Cells[0].Value.ToString(), Convert.ToInt32(insertTable.Rows[0].Cells[1].Value), insertTable.Rows[0].Cells[2].Value.ToString(), Convert.ToInt32(insertTable.Rows[0].Cells[3].Value), insertTable.Rows[0].Cells[4].Value.ToString(), repairs, characteristics, driver);
                TransportCollection.InsertOne(transports);
                ReadDataTransport();
            }
            else if (Mode == "Brigades")
            {
                BsonDocument brigadir = new BsonDocument { { "фамилия", insertTable.Rows[0].Cells[1].Value.ToString() }, { "_id", insertTable.Rows[0].Cells[2].Value.ToString() } };
                BsonArray drivers = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[3].Value != null && insertTable.Rows[i].Cells[4].Value != null)
                    {
                        drivers.Add(new BsonDocument { { "фамилия", insertTable.Rows[i].Cells[3].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[4].Value.ToString() } });
                    }
                }
                BsonDocument foreman = new BsonDocument { { "фамилия", insertTable.Rows[0].Cells[5].Value.ToString() }, { "_id", insertTable.Rows[0].Cells[6].Value.ToString() } };
                BsonDocument supervisor = new BsonDocument { { "фамилия", insertTable.Rows[0].Cells[8].Value.ToString() }, { "_id", insertTable.Rows[0].Cells[9].Value.ToString() } };
                BsonArray workers = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[10].Value != null && insertTable.Rows[i].Cells[11].Value != null)
                    {
                        workers.Add(new BsonDocument { { "фамилия", insertTable.Rows[i].Cells[10].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[11].Value.ToString() } });
                    }
                }
                Brigades brigades = new Brigades(insertTable.Rows[0].Cells[0].Value.ToString(), brigadir, drivers, foreman, insertTable.Rows[0].Cells[7].Value.ToString(), supervisor, workers);
                BrigadesCollection.InsertOne(brigades);
                ReadDataBrigades();
            }
            else if (Mode == "Repairs")
            {
                BsonArray members = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[5].Value != null && insertTable.Rows[i].Cells[6].Value != null)
                    {
                        members.Add(new BsonDocument { { "фамилия", insertTable.Rows[i].Cells[5].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[6].Value.ToString() } });
                    }
                }
                Repairs repairs = new Repairs(insertTable.Rows[0].Cells[0].Value.ToString(), Convert.ToDateTime(insertTable.Rows[0].Cells[1].Value), insertTable.Rows[0].Cells[2].Value.ToString(), Convert.ToInt32(insertTable.Rows[0].Cells[3].Value), insertTable.Rows[0].Cells[4].Value.ToString(), members);
                RepairsCollection.InsertOne(repairs);
                ReadDataRepairs();
            }
            else if (Mode == "Routes")
            {
                BsonArray dates = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[1].Value != null && insertTable.Rows[i].Cells[2].Value != null)
                    {
                        dates.Add(new BsonDocument { { "дата", insertTable.Rows[i].Cells[1].Value.ToString() }, { FeatureAdd, insertTable.Rows[i].Cells[2].Value.ToString() } });
                    }
                }
                BsonArray transports = new BsonArray();
                for (int i = 0; i < insertTable.RowCount - 1; i++)
                {
                    if (insertTable.Rows[i].Cells[5].Value != null && insertTable.Rows[i].Cells[6].Value != null)
                    {
                        transports.Add(new BsonDocument { { Feature, insertTable.Rows[i].Cells[5].Value.ToString() }, { "_id", insertTable.Rows[i].Cells[6].Value.ToString() } });
                    }
                }
                Routes routes = new Routes(insertTable.Rows[0].Cells[0].Value.ToString(), dates, insertTable.Rows[0].Cells[3].Value.ToString(), insertTable.Rows[0].Cells[4].Value.ToString(), transports);
                RoutesCollection.InsertOne(routes);
                ReadDataRoutes();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Mode == "Staff")
            {
                StaffCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataStaff();
            }
            else if (Mode == "Drivers")
            {
                DriversCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataDrivers();
            }
            else if (Mode == "Facilities")
            {
                FacilitiesCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataFacilities();
            }
            else if (Mode == "Transport")
            {
                TransportCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataTransport();
            }
            else if (Mode == "Brigades")
            {
                BrigadesCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataBrigades();
            }
            else if (Mode == "Repairs")
            {
                RepairsCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataRepairs();
            }
            else if (Mode == "Routes")
            {
                RoutesCollection.DeleteOne(x => x.Id == insertTable.Rows[0].Cells[0].Value.ToString());
                ReadDataRoutes();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (Mode == "Transport")
            {
                for (int i = 0; i < insertTable.ColumnCount; i++)
                {
                    if (insertTable.Columns[i].HeaderText == "вместимость")
                    {
                        insertTable.Columns[i].HeaderText = "грузоподъемность";
                        Feature = "грузоподъемность";
                        break;
                    }
                    else if (insertTable.Columns[i].HeaderText == "грузоподъемность")
                    {
                        insertTable.Columns[i].HeaderText = "интенсивность";
                        Feature = "интенсивность";
                        break;
                    }
                    else if (insertTable.Columns[i].HeaderText == "интенсивность")
                    {
                        insertTable.Columns[i].HeaderText = "вместимость";
                        Feature = "вместимость";
                        break;
                    }
                }
            }
            else if (Mode == "Routes")
            {
                for (int i = 0; i < insertTable.ColumnCount; i++)
                {
                    if (insertTable.Columns[i].HeaderText == "вместимость транспорта")
                    {
                        insertTable.Columns[i].HeaderText = "грузоподъемность транспорта";
                        Feature = "грузоподъемность";
                        break;
                    }
                    else if (insertTable.Columns[i].HeaderText == "грузоподъемность транспорта")
                    {
                        insertTable.Columns[i].HeaderText = "вместимость транспорта";
                        Feature = "вместимость";
                        break;
                    }
                }

                for (int i = 0; i < insertTable.ColumnCount; i++)
                {
                    if (insertTable.Columns[i].HeaderText == "объем грузоперевозки")
                    {
                        insertTable.Columns[i].HeaderText = "число пассажиров";
                        FeatureAdd = "число_пассажиров";
                    }
                    else if (insertTable.Columns[i].HeaderText == "число пассажиров")
                    {
                        insertTable.Columns[i].HeaderText = "объем грузоперевозки";
                        FeatureAdd = "объем_грузоперевозки";
                    }
                }
            }
        }
    }
}
