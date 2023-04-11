using Nhom1_LapTrinhWeb_CNTT2_K61.Models;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.Repository
{
    public interface IDiaDiemRepository
    {
        TquocGium Add(TquocGium quocgia);
		//Để thêm vào CSDL
		TquocGium Update(TquocGium quocgia);
        //Để update CSDL
        TquocGium Delete(String MaQg);
        //Để xóa CSDL
        TquocGium GetQuocGia(String MaQg);
        //Để tìm trong CSDL
        IEnumerable<TquocGium> GetQuocGia();
        //Để lấy toàn bộ CSDL

    }
}
