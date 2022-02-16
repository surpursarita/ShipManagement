import http from "../Common/Http-Common";
import IShipData from "../Types/Ship.Type"

class ShipDataService {
    getAll() {
        return http.get<Array<IShipData>>("/Ship/getships");
    }

    get(id: string) {
        return http.get<IShipData>(`/ship/${id}`);
    }

    create(data: IShipData) {
        return http.post<IShipData>("/ship", data);
    }

    update(data: IShipData) {
        return http.put<any>(`/ship`, data);
    }

    delete(id: any) {
        return http.delete<any>(`/ships/${id}`);
    }
}

export default new ShipDataService();