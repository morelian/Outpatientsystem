using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outpatientsystem.DataAccessLayer
{
    internal interface IDoctorDal
    {
        /// <summary>
		/// 插入医生；
		/// </summary>
		/// <param name="doctor">医生</param>
		/// <returns>受影响行数</returns>
		int Insert(DoctorModle doctor);
        /// <summary>
        /// 查询医生；
        /// </summary>
        /// <param name="doctorNo">医生号</param>
        /// <returns>医生</returns>
        DoctorModle Select(string doctorNo);
        /// <summary>
        /// 查询医生计数;
        /// </summary>
        /// <param name="doctorNo">医生号</param>
        /// <returns>计数</returns>
        int SelectCount(string doctorNo);
        /// <summary>
        /// 更新医生；
        /// </summary>
        /// <param name="doctor">医生</param>
        /// <returns>受影响行数</returns>
        int Update(DoctorModle doctor);
        /// <summary>
        /// 开药
        /// </summary>
        /// <param name="no">药品编号</param>
        /// <param name="zno">诊单编号</param>
        void ExtractRoot(string no, string zno);

        void changepw(string no, string pw);
        DoctorModle Show(string no);
        DataTable buildtable();
        DataTable WorksheetShow();
       DataSet buildkesitree();
    }
}
