using Microsoft.AspNetCore.Mvc;
using Nhom1_LapTrinhWeb_CNTT2_K61.Repository;

namespace Nhom1_LapTrinhWeb_CNTT2_K61.ViewComponents
{
    public class QuocGiaMenuViewComponent:ViewComponent
    {
        
            private readonly IDiaDiemRepository _maNuoc;

            public QuocGiaMenuViewComponent(IDiaDiemRepository MaQg)
            {
                _maNuoc = MaQg;
            }

            public IViewComponentResult Invoke()
            {
                var manuoc = _maNuoc.GetQuocGia().OrderBy(x => x.MaQg);
                return View(manuoc);
            }
        }
    }
