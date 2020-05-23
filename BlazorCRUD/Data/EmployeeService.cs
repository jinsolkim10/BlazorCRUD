using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        //CRUD 작동

        //Get All Employee 동작구조 ApplicationDbContext에 있는 생성한 데이터 베이스를 리스트 배열로 불러온다.

        public List<EmployeeInfo> GetEmployee()
        {
            var empList = _db.Employees.ToList();//받아옴
            return empList;//다시 데이터 베이스로 보냄
        }

        /// <summary>
        /// Get Employee By Id 
        /// </summary>
        public EmployeeInfo GetEmployeeById(int id)//매서드 생성
        {
            EmployeeInfo employee = _db.Employees.FirstOrDefault(s => s.EmployeeId == id);//람다식으로 EmployeeId와 Int id가 같으면 리턴, Null이면 널값 리턴
            return employee;
        }

        //employee info 생성(Insert)
        public string Create(EmployeeInfo objEmployee)//추가하는 매서드 생성
        {
            _db.Employees.Add(objEmployee);//EmployeeInfo에 존재하는 객체를 데이터베이스에 추가함(Add)
            _db.SaveChanges();//데이터 베이스에 실제로 적용한다.
            return "성공적으로 저장되었습니다.";
        }


        //Employee Info 편집(Update)
        public string UpdateEmployee(EmployeeInfo objEmployee)//업데이트하는 매서드 생성
        {
            _db.Employees.Update(objEmployee);//EmployeeInfo에 존재하는 객체를 데이터베이스에 업데이트함(Update)
            _db.SaveChanges();//데이터 베이스에 실제로 적용한다.
            return "편집완료";
        }

        //Eployee Info 삭제(Delete)
        public string DeleteEmpInfo(EmployeeInfo objEmployee)//삭제하는 매서드 생성
        {
            _db.Remove(objEmployee);//objEmployee에 존재하는 데이터를 데이터베이스에 제거함(Remove)
            _db.SaveChanges();//데이터 베이스에 실제로 적용한다.
            return "삭제완료";
        }
    }
}
