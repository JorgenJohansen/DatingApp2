export interface Group {
    name: string;
    connections: Connection[];
}

interface Connection {
    conntectionId: string;
    username: string;
}