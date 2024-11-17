import React from 'react'
import Table from '../components/table/Table'

const Columns = [
    { key: 'name', header: 'Название товара' },
    { key: 'date', header: 'Дата' },
    { key: 'count', header: 'Количество' },
]

const data = [
    { name: 'Товар 1', date: '01.01.2023', count: 10 },
    { name: 'Товар 2', date: '02.01.2023', count: 20 },
    { name: 'Товар 3', date: '03.01.2023', count: 30 },
]

function ReadyProduction() {
  return (
    <>
        <div style={{ marginTop: '10px' }}>Готовое производство</div>
        <Table columns={Columns} data={data} />
    </>
  );
}

export default ReadyProduction