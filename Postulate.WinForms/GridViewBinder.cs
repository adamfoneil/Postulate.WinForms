using Postulate.Orm.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Postulate.WinForms
{
	public class GridViewBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
	{
		private readonly DataGridView _dataGridView;
		private readonly SqlDb<TKey> _db;
		private TRecord _record;
		private bool _dirty = false;
        private DataGridViewRow _deleteRow;

		public GridViewBinder(DataGridView dataGridView, SqlDb<TKey> sqlDb)
		{
			_dataGridView = dataGridView;
			_dataGridView.CurrentCellDirtyStateChanged += CellDirty;
			_dataGridView.RowValidated += RowValidated;
			_dataGridView.UserDeletingRow += RowDeleting;
			_dataGridView.UserDeletedRow += RowDeleted;
			_db = sqlDb;
		}

		private void RowDeleting(object sender, DataGridViewRowCancelEventArgs e)
		{
			_record = e.Row.DataBoundItem as TRecord;
            _deleteRow = e.Row;
		}

		private void RowDeleted(object sender, DataGridViewRowEventArgs e)
		{
            try
            {
                if (_record != null)
                {
                    _db.DeleteOne(_record);
                    _record = null;
                }
            }
            catch (Exception exc)
            {
                if (_deleteRow != null)
                {
                    _deleteRow.ErrorText = exc.Message;
                }
                else
                {
                    MessageBox.Show(exc.Message);
                }
            }
		}

		private void RowValidated(object sender, DataGridViewCellEventArgs e)
		{
            var row = _dataGridView.Rows[e.RowIndex];
            try
            {                
                if (_dirty)
                {
                    if (_record != null)
                    {
                        _db.Save(_record);
                        row.ErrorText = null;
                        _record = null;
                    }
                    _dirty = false;
                }
            }
            catch (Exception exc)
            {
                row.ErrorText = exc.Message;
            }
		}

		private void CellDirty(object sender, EventArgs e)
		{
			if (_dataGridView.IsCurrentCellDirty)
			{
				_dirty = true;
				_record = _dataGridView.CurrentRow.DataBoundItem as TRecord;
			}
		}

		public void Fill(IEnumerable<TRecord> records)
		{
			BindingList<TRecord> list = new BindingList<TRecord>();
			foreach (var record in records) list.Add(record);

			BindingSource bs = new BindingSource();
			bs.DataSource = list;
			_dataGridView.DataSource = bs;

			if (records.Any()) _record = records.First();
		}
	}
}