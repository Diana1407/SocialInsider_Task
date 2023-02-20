import {
    useQuery
} from '@tanstack/react-query'

function Profiles() {
    const { isLoading, error, data } = useQuery({
        queryKey: ["Profiles"],
        queryFn: () => fetch('api/profiles').then((res) => res.json())
    })

    if (isLoading) return 'Loading....'

    if (error) return error.message

    return (null)
    /*return (
        *//*<table>
            <tr>
                <th>Index</th>
                <th>Brands Name</th>
            </tr>
            {data.map((brand, index) => <tr>
                <td>{index + 1}</td>
                <td>{brand.name}</td>
            </tr>)}
        </table>*//*
    )*/
}
export { Profiles }