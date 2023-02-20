import {
    useQuery
}from '@tanstack/react-query'

function Brands() {
    const { isLoading, error, data } = useQuery({
        queryKey: ["Brands"],
        queryFn: () => fetch('api/brands').then((res) => res.json())
    })

    if (isLoading) return 'Loading....'

    if (error) return error.message

    return (
        <table>
                <tr>
                    <th><center>Index</center></th>
                    <th><center>Brands Name</center></th>
                    <th><center>Brands Counter</center></th>
                </tr>
                {data.map((brand, index) => <tr>
                    <td>{index + 1}</td>
                    <td>{brand.name}</td>
                    <td>{brand.counter}</td>
                </tr>)}
        </table>
        )
}
export { Brands }