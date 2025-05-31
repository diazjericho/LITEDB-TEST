using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITEDB_TEST {
    using LiteDB;

    public class LiteDbService {
        public void InsertUser(User user) {
            using (var db = new LiteDatabase("Filename=MyDatabase.db;Connection=Shared")) {
                var users = db.GetCollection<User>("users");
                users.Insert(user);
                LogHistory("Added", user, "N/A", "N/A", "N/A");
            }
        }

        public List<User> GetUsers() {
            using (var db = new LiteDatabase("Filename=MyDatabase.db;Connection=Shared")) {
                return db.GetCollection<User>("users").Query().ToList();
            }
        }

        public void UpdateUser(User user) {
            using (var db = new LiteDatabase("Filename=MyDatabase.db;Connection=Shared")) {
                var users = db.GetCollection<User>("users");
                var oldUser = users.FindById(user.Id);

                if (oldUser != null) {
                    // Check for changes dynamically
                    if (oldUser.Name != user.Name)
                        LogHistory("Updated", user, "Name", oldUser.Name, user.Name);

                    if (oldUser.Age != user.Age)
                        LogHistory("Updated", user, "Age", oldUser.Age.ToString(), user.Age.ToString());

                    users.Update(user);
                }
            }
        }

        public void DeleteUser(int id) {
            using (var db = new LiteDatabase("Filename=MyDatabase.db;Connection=Shared")) {
                var users = db.GetCollection<User>("users");
                var user = users.FindById(id);
                if (user != null) {
                    LogHistory("Deleted", user, "N/A", "N/A", "N/A");
                    users.Delete(id);
                }
            }
        }

        public void LogHistory(string action, User user, string field, string oldValue, string newValue) {
            using (var db = new LiteDatabase("Filename=MyDatabase.db;Connection=Shared")) {
                var history = db.GetCollection<HistoryRecord>("history");
                history.Insert(new HistoryRecord {
                    Action = action,
                    UserName = user.Name,
                    ChangedField = field,
                    OldValue = oldValue,
                    NewValue = newValue,
                    Timestamp = DateTime.Now
                });
            }
        }

    }

}
