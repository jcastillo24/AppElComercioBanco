using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationElComercio.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Models.Banco, Entities.Banco>()
                .ForMember(x=> x.Id, y=> y.MapFrom(src => src.idbanco));
            CreateMap<Entities.Banco, Models.Banco>()
                .ForMember(x => x.idbanco, y => y.MapFrom(src => src.Id));

            CreateMap<Models.Sucursal, Entities.Sucursal>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.idsucursal))
                .ForMember(x => x.BancoId, y => y.MapFrom(src => src.idbanco));
            CreateMap<Entities.Sucursal, Models.Sucursal>()
                .ForMember(x => x.idsucursal, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.idbanco, y => y.MapFrom(src => src.BancoId)); ;

            CreateMap<Models.OrdenPago, Entities.OrdenPago>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.idordenpago))
                .ForMember(x => x.SucursalId, y => y.MapFrom(src => src.idsucursal));
            CreateMap<Entities.OrdenPago, Models.OrdenPago>()
                .ForMember(x => x.idordenpago, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.idsucursal, y => y.MapFrom(src => src.SucursalId));


        }
    }
}
