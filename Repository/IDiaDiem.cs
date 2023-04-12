using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Repository
{
    public interface IDiaDiem
    {
        TquocGium Add(TquocGium quocgia);
		//Để thêm vào CSDL
		TquocGium Update(TquocGium quocgia);
        //Để update CSDL
        TquocGium Delete(int MaQg);
        //Để xóa CSDL
        TquocGium GetQuocGia(int MaQg);
        //Để tìm trong CSDL
        IEnumerable<TquocGium> GetAllQuocGia();
        //Để lấy toàn bộ CSDL

    }
}
