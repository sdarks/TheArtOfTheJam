﻿
public class PuzzleNode
{
    public PuzzleNode next;
    public PuzzleNode prev;

    public RoomAction requirement;

    public PuzzleNode(PuzzleNode prev, PuzzleNode next, RoomAction requirement)
    {
        if (prev != null) prev.next = this;
        if (next != null) next.prev = this;

        this.next = next;
        this.prev = prev;

        this.requirement = requirement;
    }


}
