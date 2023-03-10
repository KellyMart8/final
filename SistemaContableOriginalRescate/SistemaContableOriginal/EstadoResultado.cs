using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaContableOriginal
{
    public partial class EstadoResultado : Form
    {
        
        private Conectar conn;
        int n;
        double valor, a, b, cb, rb, gv, ga, roo, ingf, gf, ingE, gasE, ingEjAnt, gia, raig, imp, rn;

        public EstadoResultado(Conectar conn)
        {
            this.conn = conn;
            InitializeComponent();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (mtIngAct.Text == "" || mTDescuentoBon.Text == "" || mTCosteBienesVernd.Text == ""
                || mTGastoVentas.Text == "" || mTGastosAdm.Text == "" || mtIngresosFinancieros.Text == ""
                || mTGastosFinancieros.Text == "" || mTIngresosExtra.Text == "" || mTGastosExtra.Text == ""
                || mTIngresoEjreAnteriores.Text == "" || mTGastoEjreAnteriores.Text == "" || mtImpGanancias.Text == "" 
                || txtIngrOperaNeto.Text == "" || txtReslBruto.Text == "" || txtResultadoOperOrdinarias.Text == ""
                || txtResultImpuestoGanancias.Text == "" || txtUtiliodadNeta.Text == "")
            {
                MessageBox.Show("Campos vacios");
                return;
            }
            conn.insertarER(Convert.ToDouble(mtIngAct.Text), Convert.ToDouble(mTDescuentoBon.Text), 
                Convert.ToDouble(mTCosteBienesVernd.Text),
                 Convert.ToDouble(mTGastoVentas.Text), Convert.ToDouble(mTGastosAdm.Text), Convert.ToDouble(mtIngresosFinancieros.Text),
                 Convert.ToDouble(mTGastosFinancieros.Text), Convert.ToDouble(mTIngresosExtra.Text), Convert.ToDouble(mTGastosExtra.Text),
                Convert.ToDouble(mTIngresoEjreAnteriores.Text), Convert.ToDouble(mTGastoEjreAnteriores.Text), Convert.ToDouble(mtImpGanancias.Text),
                Convert.ToDouble(txtIngrOperaNeto.Text), Convert.ToDouble(txtReslBruto.Text), Convert.ToDouble(txtResultadoOperOrdinarias.Text),
                Convert.ToDouble(txtResultImpuestoGanancias.Text), Convert.ToDouble(txtUtiliodadNeta.Text));
            this.Hide();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void EstadoResultado_Load(object sender, EventArgs e)
        {
        }
        private void mTGastoEjreAnteriores_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public EstadoResultado()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        public void btnCalc_Click(object sender, EventArgs e)
        {
            if (mtIngAct.Text == "" || mTDescuentoBon.Text == "" || mTCosteBienesVernd.Text == ""
                || mTGastoVentas.Text == "" || mTGastosAdm.Text == "" || mtIngresosFinancieros.Text == ""
                || mTGastosFinancieros.Text == "" || mTIngresosExtra.Text == "" || mTGastosExtra.Text == ""
                || mTIngresoEjreAnteriores.Text == "" || mTGastoEjreAnteriores.Text == "" || mtImpGanancias.Text == "")
            {
                MessageBox.Show("No deje ningun campo vacio e ingrese los datos en orden de columnas", "ATENCION");
                mtIngAct.Focus();
            }
            else
            {

                a = Convert.ToDouble(mtIngAct.Text);
                b = Convert.ToDouble(mTDescuentoBon.Text);

                valor = a - b;
                txtIngrOperaNeto.Text = valor.ToString();

                //Resultado bruto 
                cb = Convert.ToDouble(mTCosteBienesVernd.Text);
                rb = valor - cb;
                txtReslBruto.Text = rb.ToString();

                //Resultado de operaciones ordinarias
                gv = Convert.ToDouble(mTGastoVentas.Text);
                ga = Convert.ToDouble(mTGastosAdm.Text);
                roo = rb - gv - ga;
                txtResultadoOperOrdinarias.Text = roo.ToString();

                //Resultado ANTES del mimpuesto a las ganancias
                ingf = Convert.ToDouble(mtIngresosFinancieros.Text);
                gf = Convert.ToDouble(mTDescuentoBon.Text);
                ingE = Convert.ToDouble(mTIngresosExtra.Text);
                gasE = Convert.ToDouble(mTGastosExtra.Text);
                ingEjAnt = Convert.ToDouble(mTIngresoEjreAnteriores.Text);
                gia = Convert.ToDouble(mTGastoEjreAnteriores.Text);
                raig = roo + ingf - gf + ingE - gasE + ingEjAnt - gia;

                txtResultImpuestoGanancias.Text = raig.ToString();

                // Resultado neto
                imp = Convert.ToDouble(mtImpGanancias.Text);
                rn = raig - imp;
                txtUtiliodadNeta.Text = rn.ToString();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //if (n != -1)
            //{
            //    dataGridView1.Rows.RemoveAt(n);
            //}

            Limpiar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            n = dataGridView1.Rows.Add();

            dataGridView1.Rows[n].Cells[0].Value = "Ingreso por actividades";
            dataGridView1.Rows[n].Cells[1].Value = mtIngAct.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Descuento por bonificaciones";
            dataGridView1.Rows[n].Cells[1].Value = mTDescuentoBon.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Ingresos Operativos netos";
            dataGridView1.Rows[n].Cells[1].Value = txtIngrOperaNeto.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Coste de los bienes vendidos";
            dataGridView1.Rows[n].Cells[1].Value = mTCosteBienesVernd.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Resultado bruto";
            dataGridView1.Rows[n].Cells[1].Value = txtReslBruto.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Gasto de ventas";
            dataGridView1.Rows[n].Cells[1].Value = mTGastoVentas.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Gasto de administracions";
            dataGridView1.Rows[n].Cells[1].Value = mTGastosAdm.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Resultado de las operaciones ordinarias";
            dataGridView1.Rows[n].Cells[1].Value = txtResultadoOperOrdinarias.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Ingresos financieros";
            dataGridView1.Rows[n].Cells[1].Value = mtIngresosFinancieros.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Gastos financieros";
            dataGridView1.Rows[n].Cells[1].Value = mTGastosFinancieros.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Ingresos extraordinarios";
            dataGridView1.Rows[n].Cells[1].Value = mTIngresosExtra.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Gastos extraordinarios";
            dataGridView1.Rows[n].Cells[1].Value = mTGastosExtra.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Ingreso de ejercicios anteriores";
            dataGridView1.Rows[n].Cells[1].Value = mTIngresoEjreAnteriores.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Gastos de ejercicios anteriores";
            dataGridView1.Rows[n].Cells[1].Value = mTGastoEjreAnteriores.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Resultado antes del impuesto de las ganancias";
            dataGridView1.Rows[n].Cells[1].Value = txtResultImpuestoGanancias.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Impuesto a las ganancias ";
            dataGridView1.Rows[n].Cells[1].Value = mtImpGanancias.Text;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "Resultado neto";
            dataGridView1.Rows[n].Cells[1].Value = txtUtiliodadNeta.Text;

            String insertar = "INSERT INTO EstadoResultadoIngresosActividades, DescuentosBonificaciones, IngresosOperativosNetos, CostoBienesVendidos, ResultadoBruto, GastosVentas, GastosAdministración, ResultadoOperacionesOrdinarias, IngresosFinancieros, GastosFinancieros, IngresosExtraordinarios, GastosExtraordinarios, IngresosEjerciciosAnteriores, GastosIngresosAnteriores, ResultadoANTESImpuesto, ImpuestoGanancias, ResultadoNeto) VALUES (@IngresosActividades, @DescuentosBonificaciones, @IngresosOperativosNetos, @CostoBienesVendidos, @ResultadoBruto, @GastosVentas, @GastosAdministración, @ResultadoOperacionesOrdinarias, @IngresosFinancieros, @GastosFinancieros, @IngresosExtraordinarios, @GastosExtraordinarios, @IngresosEjerciciosAnteriores, @GastosIngresosAnteriores, @ResultadoANTESImpuesto, @ImpuestoGanancias, @ResultadoNeto";
            SqlCommand cmd1 = new SqlCommand(insertar);
            cmd1.Parameters.AddWithValue("@IngresosActividades", mtIngAct);
            cmd1.Parameters.AddWithValue("@DescuentosBonificaciones", mTDescuentoBon);
            cmd1.Parameters.AddWithValue("@IngresosOperativosNetos", txtIngrOperaNeto);
            cmd1.Parameters.AddWithValue("@CostoBienesVendidos", mTCosteBienesVernd);
            cmd1.Parameters.AddWithValue("@ResultadoBruto", txtReslBruto);
            cmd1.Parameters.AddWithValue("@GastosVentas", mTGastoVentas);
            cmd1.Parameters.AddWithValue("@GastosAdministración", mTGastosAdm);
            cmd1.Parameters.AddWithValue("@ResultadoOperacionesOrdinarias", txtResultadoOperOrdinarias);
            cmd1.Parameters.AddWithValue("@IngresosFinancieros", mtIngresosFinancieros);
            cmd1.Parameters.AddWithValue("@GastosFinancieros", mTGastosFinancieros);
            cmd1.Parameters.AddWithValue("@IngresosExtraordinarios", mTIngresosExtra);
            cmd1.Parameters.AddWithValue("@GastosExtraordinarios", mTGastosExtra);
            cmd1.Parameters.AddWithValue("@IngresosEjerciciosAnteriores", mTIngresoEjreAnteriores);
            cmd1.Parameters.AddWithValue("@GastosIngresosAnteriores", mTIngresoEjreAnteriores);
            cmd1.Parameters.AddWithValue("@ResultadoANTESImpuesto", txtResultImpuestoGanancias);
            cmd1.Parameters.AddWithValue("@ImpuestoGanancias", mtImpGanancias);
            cmd1.Parameters.AddWithValue("@ResultadoNeto", txtUtiliodadNeta);

            cmd1.ExecuteNonQuery();

        }




        public void Limpiar()
        {
            mtIngAct.Clear();
            mTDescuentoBon.Clear();
            txtIngrOperaNeto.Clear();
            mTCosteBienesVernd.Clear();
            txtReslBruto.Clear();
            mTGastoVentas.Clear();
            mTGastosAdm.Clear();
            txtResultadoOperOrdinarias.Clear();
            mtIngresosFinancieros.Clear();
            mTGastosFinancieros.Clear();
            mTIngresosExtra.Clear();
            mTGastosExtra.Clear();
            mTIngresoEjreAnteriores.Clear();
            mTGastoEjreAnteriores.Clear();
            txtResultImpuestoGanancias.Clear();
            mtImpGanancias.Clear();
            txtUtiliodadNeta.Clear();

            // DataGridView.Rows.Clear()

            //for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            //{
            //    dataGridView1.Rows.RemoveAt(i);
            //}

            //this.Controls.Remove(dataGridView1);
        }
    }
}
