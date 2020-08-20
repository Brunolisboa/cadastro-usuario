using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Loja.DTO;
using Loja.BLL;

namespace Loja {
    public partial class CadastroUsuario : Form 
    {
        string modo = "";
        int codUsuSelecionado = -1;

        public CadastroUsuario() 
        {
            InitializeComponent();
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)
        {
            carregaGrid();
            lblMensagem.Text = "";
        }

        private void carregaGrid() 
        {
            try 
            {
                IList<UsuarioDTO> listUsuario_DTO = new List<UsuarioDTO>();
                listUsuario_DTO = new UsuarioBLL().cargaUsuario();
                dataGridView.DataSource = listUsuario_DTO;
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
            int sel = dataGridView.CurrentRow.Index;
            txtNome.Text = Convert.ToString(dataGridView["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView["cadastro", sel].Value);
            codUsuSelecionado = Convert.ToInt32(dataGridView["cod_usuario", sel].Value);
            lblMensagem.Text = "";
            if (Convert.ToString(dataGridView["situacao", sel].Value) == "A") 
            {
                cboSituacao.Text = "Ativo";
            } 
            else 
            {
                cboSituacao.Text = "Inativo";
            }
            switch (Convert.ToString(dataGridView["perfil", sel].Value)) 
            {
                case "1":
                    cboPerfil.Text = "Administrador";
                    break;
                case "2":
                    cboPerfil.Text = "Operador";
                    break;
                case "3":
                    cboPerfil.Text = "Gerencial";
                    break;
            }
        }
        
        private void btnNovo_Click(object sender, EventArgs e) {
            limpar_campos();
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);
            modo = "novo";
        }

        private void btnEditar_Click(object sender, EventArgs e) 
        {
            if (codUsuSelecionado < 0) 
            {
                lblMensagem.Text = "Selecione um usuário antes de prosseguir";
                return;
            }
            modo = "edita";
        }

        private void btnDeletar_Click(object sender, EventArgs e) 
        {
            if (codUsuSelecionado < 0) 
            {
                lblMensagem.Text = "Selecione um usuário antes de prosseguir";
                return;
            } 
            else 
            {
                lblMensagem.Text = "";
                modo = "excluir";
                MessageBox.Show("Para excluir o usuário, clique em Confirmar");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e) {
            if (modo == "novo") {
                try {
                    UsuarioDTO USU = new UsuarioDTO();
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo") {
                        USU.situacao = "A";
                    } else {
                        USU.situacao = "I";
                    }
                    switch (cboPerfil.Text) {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;
                    }
                    int x = new UsuarioBLL().insereUsuario(USU);
                    if (x > 0) {
                        MessageBox.Show("Gravado com Sucesso!");
                    }
                    carregaGrid();
                } catch (Exception ex) {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }
            if (modo == "edita") {
                try {
                    if (codUsuSelecionado < 0) {
                        lblMensagem.Text = "Selecione um usuário antes de prosseguir";
                        return;
                    }
                    UsuarioDTO USU = new UsuarioDTO();
                    USU.cod_usuario = codUsuSelecionado;
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo") {
                        USU.situacao = "A";
                    } else {
                        USU.situacao = "I";
                    }
                    switch (cboPerfil.Text) {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;
                    }
                    int x = new UsuarioBLL().editaUsuario(USU);
                    if (x > 0) {
                        MessageBox.Show("Alterado com Sucesso!");
                    }
                    carregaGrid();
                } catch (Exception ex) {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }
            if (modo == "excluir") {
                try {
                    if (codUsuSelecionado < 0) {
                        lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        return;
                    }
                    UsuarioDTO USU = new UsuarioDTO();
                    USU.cod_usuario = codUsuSelecionado;
                    int x = new UsuarioBLL().deletaUsuario(USU);
                    if (x > 0) {
                        MessageBox.Show("Excluido com Sucesso!");
                    }
                    carregaGrid();
                    limpar_campos();
                } catch (Exception ex) {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }
            modo = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            limpar_campos();
            modo = "";
        }

        private void limpar_campos() {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCadastro.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";
        }
    }
}
