﻿using System;
using System.Collections.Generic;
using Loja.DAL;
using Loja.DTO;

namespace Loja.BLL {
    public class UsuarioBLL
    {
        public IList<UsuarioDTO> cargaUsuario()
        {
            try { return new UsuarioDAL().cargaUsuario(); } 
            catch (Exception ex) { throw ex; }
        }
        public int insereUsuario(UsuarioDTO USU) 
        {
            try { return new UsuarioDAL().insereUsuario(USU); } 
            catch (Exception ex) { throw ex; }
        }
        public int editaUsuario(UsuarioDTO USU) 
        {
            try { return new UsuarioDAL().editaUsuario(USU); } 
            catch (Exception ex) { throw ex; }
        }
        public int deletaUsuario(UsuarioDTO USU) 
        {
            try { return new UsuarioDAL().deletaUsuario(USU); } 
            catch (Exception ex) { throw ex; }
        }
    }
}
