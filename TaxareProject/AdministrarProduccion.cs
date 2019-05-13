﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EN = Entities;
using CT = Controllers;
using BR = Broker;

namespace TaxareProject
{
    public partial class AdministrarProduccion : Form
    {
        private CT.Conductores conductoresController;
        private CT.Taxis taxisController;
        private CT.Marcas marcasController;
        private CT.Produccion produccionController;

        public AdministrarProduccion()
        {
            conductoresController = new CT.Conductores();
            taxisController = new CT.Taxis();
            marcasController = new CT.Marcas();
            produccionController = new CT.Produccion();
            InitializeComponent();
            llenarDataGridView();
            LlenarConductores();
            LlenarTaxis();
            txtTotal.ReadOnly = true;
            SwitchDias();

        }

        void llenarDataGridView()
        {

            dgvProducciones.AutoGenerateColumns = false;
            dgvProducciones.DataSource = produccionController.ListaProducciones();

        }

        void LlenarConductores()
        {
            List<Broker.Conductor> listConductores = conductoresController.MostrarConductores();

            cmbConductor.Items.Clear();

            foreach (var item in listConductores)
            {
                //Conductores  a la hora de agragrar una produccion
                cmbConductor.Items.Add(new EN.itemList(item.id,item.nombre.ToUpper()+" "+item.apellido.ToUpper()));
                //Conductores del cmb de la liquidacion
                cmbCondl.Items.Add(item.nombre.Trim() + " " + item.apellido.Trim());
            }

        }

        void LlenarTaxis()
        {
            List<EN.Taxis> listConductores = taxisController.MostrarTaxis();

            cmbTx.Items.Clear();
            foreach (EN.Taxis tax in listConductores)
            {

                cmbTx.Items.Add(tax.placa.Trim().ToUpper() + " " + tax.marca);
                cmbTaxisl.Items.Add(tax.placa.Trim().ToUpper() + " " + tax.marca);
            }

        }

        private void SwitchDias()
        {

            lbl.Visible = false;
            lblDias.Visible = false;

        }

        private void AdministrarProduccion_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            if (cmbConductor.Text.Length != 0 && placa != null && txtLiquidaciondia.Text.Length != 0)
            {

                //Calculo de dias liquidados
                TimeSpan resto = dtpFinal.Value.Date - dtpInicio.Value.Date;
                double total = (resto.TotalDays + 1) * Convert.ToDouble(txtLiquidaciondia.Text.Trim());
                txtDiasTrabajados.Text = (resto.TotalDays + 1).ToString();
                txtTotal.Text = total.ToString();
                txtTotal.BackColor = Color.Beige;
                txtDiasTrabajados.BackColor = Color.Beige;

            }
            else
            {

                MessageBox.Show("Revise los datos de la liquidacion");
            }
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            //Claves foraneas
            String[] DataTaxi = cmbTx.Text.Split(' ');
            EN.itemList cond = cmbConductor.SelectedItem as EN.itemList;

            if (cmbConductor.Text.Length != 0 && placa != null && txtLiquidaciondia.Text.Length != 0 && txtTotal.Text.Length != 0)
            {

                //Calculo de dias liquidados
                TimeSpan resto = dtpFinal.Value.Date - dtpInicio.Value.Date;
                double total = (resto.TotalDays + 1) * Convert.ToDouble(txtLiquidaciondia.Text.Trim());

                String placa = DataTaxi[0].Trim();

                //Instancia
                BR.Produccion p = new BR.Produccion();
                p.placa = placa;
                p.inicio = dtpInicio.Value.Date;
                p.final = dtpFinal.Value.Date;
                p.valor = total;
                p.id_taxista = (int) conductoresController.MostarConductor(cond.value).id;


                if (produccionController.CrearProduccion(p))
                {

                    MessageBox.Show("Se Añadio El Registro, el vehiculo " + DataTaxi[0] + " registra una produccion de " + p.valor + "$ desde " + p.inicio + " hasta " + p.final);
                    llenarDataGridView();
                }
                else
                {

                    MessageBox.Show("Ocurio un error, intente de nuevo");
                }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbConductor.Text = cmbTx.Text = txtLiquidaciondia.Text = txtTotal.Text = " ";
            lbl.Visible = lblDias.Visible = false;
            dtpInicio.Value = DateTime.Today;
            dtpFinal.Value = DateTime.Today;
            llenarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if ((MessageBox.Show("¿Esta seguro que desea eliminar el registro selccionado?", "Eliminacion", MessageBoxButtons.YesNo) == DialogResult.Yes) && (dgvProducciones.CurrentRow.Index != -1))
            //{
            //    long id = Convert.ToInt64(dgvProducciones.CurrentRow.Cells["id"].Value);

            //    if (controladora.EliminarPrduccion(id))
            //    {
            //        MessageBox.Show("Se elimino el registro correctamente");
            //        llenarDataGridView();
            //    }
            //    else
            //    {

            //        MessageBox.Show("El registro no se encuentra o debe seleccionar uno");
            //    }
            //}
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            //Claves foraneas
            String[] Dataconductor = cmbConductor.Text.Split(' ');
            String[] DataTaxi = cmbTx.Text.Split(' ');

            //if (cmbConductor.Text.Length != 0 && placa != null && txtLD.Text.Length != 0 && txtTotal.Text.Length != 0)
            //{

            //    //Calculo de dias liquidados
            //    TimeSpan resto = dtpFinal.Value.Date - dtpInicio.Value.Date;
            //    double total = (resto.TotalDays + 1) * Convert.ToDouble(txtLD.Text.Trim());


            //    int idDriver = (int)conductores.MostarIdConductor(Dataconductor[0].Trim());
            //    String placa = DataTaxi[0].Trim();

            ////Instancia
            //Produccion p = new Produccion();
            //p.id = controladora.id(idDriver);
            //p.id_taxista = idDriver;
            //p.placa = placa;
            //p.inicio = dtpInicio.Value.Date;
            //p.final = dtpFinal.Value.Date;
            //p.valor = total;
            //txtTotal.Text = total.ToString();

            //if (controladora.ActualizarProduccion(p))
            //{

            //    MessageBox.Show("Se Actualizo el Registro");
            //    llenarDataGridView();
            //}
            //else
            //{

            //    MessageBox.Show("Ocurio un error, intente de nuevo");
            //}
            //}
        }

        private void dgvProducciones_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProducciones.CurrentRow.Index != -1)
            {
                //Produccion other = controladora.produccion(Convert.ToInt32(dgvProducciones.CurrentRow.Cells["id"].Value));
                //Taxi t = txs.GetTaxi(other.placa);
                //Conductor b = conductores.MostarConductor(other.id_taxista);

                ////Pintar los datos
                //cmbTx.Text = (t.placa.Trim().ToUpper() + " " + mrks.MostrarMarca_String(t.id_marca).ToUpper());
                //cmbConductor.Text = (b.cedula + " " + b.nombre.Trim() + " " + b.apellido.Trim());
                //dtpInicio.Value = other.inicio;
                //dtpFinal.Value = other.final;
                //TimeSpan resto = dtpFinal.Value.Date - dtpInicio.Value.Date;
                //double pdia = other.valor / (resto.TotalDays + 1);
                //txtLD.Text = pdia.ToString();
                //txtTotal.Text = other.valor.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void dgvProducciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (rdbConductor.Checked && cmbConductor.Text.Length != 0)
            {
                //String[] Dataconductor = cmbConductor.Text.Split(' ');
                //int idDriver = (int)conductores.MostarIdConductor(Dataconductor[0].Trim());

                //List<Querys.ProduccionxTaxis> other = controladora.BuscarProduccionPorConductor(idDriver);
                //if (other.Count == 0)
                //{
                //    MessageBox.Show("No hay registros asociados al conductor de identificacion " + Dataconductor[0]);
                //}
                //else
                //{

                //    dgvProducciones.DataSource = other.ToList();
                //}


            }

            if (rdbPlaca.Checked && cmbTx.Text.Length != 0)
            {
                //String[] DataTaxi = cmbTx.Text.Split(' ');
                //String placa = DataTaxi[0].Trim();
                //List<Querys.ProduccionxTaxis> other = controladora.BuscarProduccionPorPlaca(placa);
                //if (other.Count == 0)
                //{
                //    MessageBox.Show("No hay registros asociados al vehiculo de placas " + placa);
                //}
                //else
                //{

                //    dgvProducciones.DataSource = other.ToList();
                //}


            }

            else
            {

                MessageBox.Show("Intente de nuevo");
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio i = new Inicio();
            i.Show();
        }

        private void txtLD_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTaxisl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTaxisl.SelectedIndex > -1)
            {
                string[] placa = cmbTaxisl.SelectedItem.ToString().Split(' ');

                var query = produccionController.produccionxPlaca(placa[0], dateTimePicker1.Value , dateTimePicker2.Value);

                if (query  != null)
                {
                    txtDiasLiquidacion.Text = query.dias.ToString();
                    txtIni.Text = query.inicio.Date.ToString();
                    txtfin.Text = query.final.Date.ToString();
                    txtTotalLiquidacion.Text = query.producido.ToString();
                    txtPlaca.Text = query.placa.ToString();


                    txtDiasLiquidacion.ReadOnly = true;
                    txtIni.ReadOnly = true;
                    txtfin.ReadOnly = true;
                    txtTotalLiquidacion.ReadOnly = true;
                    txtPlaca.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("Intente de nuevo y verifique que le taxi tenga producidos en este rango de fecha");
                }
            }
        }

        private void cmbCondl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCondl.SelectedIndex > -1)
            {
                string[] conductor = cmbCondl.SelectedItem.ToString().Split(' ');
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


